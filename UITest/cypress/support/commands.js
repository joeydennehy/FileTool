// ***********************************************
// This example commands.js shows you how to
// create various custom commands and overwrite
// existing commands.
//
// For more comprehensive examples of custom
// commands please read more here:
// https://on.cypress.io/custom-commands
// ***********************************************
//
//
// -- This is a parent command --
// Cypress.Commands.add("login", (email, password) => { ... })
//
//
// -- This is a child command --
// Cypress.Commands.add("drag", { prevSubject: 'element'}, (subject, options) => { ... })
//
//
// -- This is a dual command --
// Cypress.Commands.add("dismiss", { prevSubject: 'optional'}, (subject, options) => { ... })
//
//
// -- This will overwrite an existing command --
// Cypress.Commands.overwrite("visit", (originalFn, url, options) => { ... })
import 'cypress-file-upload';

//GLM ==================================================================================================

Cypress.Commands.add('glm_login', (urlkey, role, password = undefined) => {
	if (password == undefined) {
		password = Cypress.env(role).password;
	}

	cy.visit("/Home/Logon?urlkey=" + urlkey);
	cy.get("input[id='EmailAddress']").type(Cypress.env(role).login, {delay: 0});
	cy.get("input[id='Password']").type(password, {delay: 0});
	cy.get(".btn-primary").click();
	cy.get('body').then($body => {
		if ($body.find("input[id='NewPassword']").length > 0) {
			cy.get("input[id='NewPassword']").type(Cypress.env(role).password, {delay: 0});
			cy.get("input[id='ConfirmNewPassword']").type(Cypress.env(role).password, {delay: 0});
			cy.get("button:contains(Reset Password)").click();
		}
	});
});

Cypress.Commands.add('loginByForm', (username, password, urlkey) => {
	Cypress.log({
		name: 'loginByForm',
		message: `${username} | ${password}`,
	})

	return cy.request({
		method: 'POST',
		url: '/Home/Logon?urlkey=' + urlkey,
		form: true,
		body: {
			EmailAddress: username,
			Password: password,
		},
	})
});

Cypress.Commands.add('create_new_user', (first_name, last_name, login, organization = undefined, password = undefined, roles = undefined) => {
	cy.visit('/User/Create')
	cy.get("label:contains('First Name')").parent("div").find('input[type=text]').type(first_name, {delay: 0});
	cy.get("label:contains('Last Name')").parent("div").find('input[type=text]').type(last_name, {delay: 0});
	cy.get("label:contains('Email / Username')").parent("div").find('input[type=text]').type(login, {delay: 0});
	if (organization != undefined) {
		cy.get("select[id='Organization']").contains(organization).then(function ($select) {
			var value = $select[0].value;
			cy.get("select[id='Organization']").select(value, { force: true });
		});
	}
	if (password != undefined) {
		cy.get("label:contains('Password')").eq(0).parent("div").find('input[type=password]').type(password, {delay: 0});
		cy.get("label:contains('Confirm Password')").parent("div").find('input[type=password]').type(password, {delay: 0});
	}

	if (roles != undefined) {
		for (var x = 0; x < roles.length; x++) {
			if (roles[x].includes("Administrator") || roles[x].includes("GrantsManager") || roles[x].includes("Auditor")) {
				cy.get("input[id='AdministratorRoles']").click();
				cy.get("button:contains('OK')").click();
			}
			cy.get("input[id='" + roles[x] + "']").click();
		}
	}
	cy.get("button:contains(Save)").click({force:true});
	if (password == undefined || roles == undefined) {
		cy.get("button:contains('OK')").click();
	}
});

Cypress.Commands.add('proxy_as_user', (login) => {
	cy.visit('/User');
	cy.get("input[id='Login']").type(login, {delay: 0});
	cy.get("button[type='submit']").click();
	cy.get("a:contains(" + login + ")").click();
	cy.get("button:contains(OK)").click();
});

Cypress.Commands.add('proxy_from_super_admin', (urlkey) => {
	cy.request("/Foundations/LogOnAsAdministrator?foundation=" + urlkey);
});

Cypress.Commands.add('change_users_password', (login, password) => {
	cy.visit('/User');
	cy.get("input[id='Login']").type(login, {delay: 0});
	cy.get("button:contains(Search)").click();
	cy.get("a[data-original-title='Edit User']").click();
	cy.get("a:contains(Change Password)").click();
	cy.get("div[data-element-fieldcode='Contact_Password']").find('div').find('input[type=password]').type(password, {delay: 0});
	cy.get("div[data-element-fieldcode='Contact_Password_Confirmation']").find('div').find('input[type=password]').type(password, {delay: 0});
	cy.get("button:contains(Save Password)").click();
});

Cypress.Commands.add('create_new_foundation', (FoundationName, urlkey ) => {
	cy.request({
		method: 'POST',
		url: '/Foundations/Create',
		form: true,
		body: {
			'FoundationDetails.Name': FoundationName,
			'FoundationDetails.UrlKey': urlkey,
			'FoundationDetails.IsActive': 'true',
			'PrimaryActorDetails.FirstName': Cypress.env("admin").first_name,
			'PrimaryActorDetails.LastName': Cypress.env("admin").last_name,
			'PrimaryActorDetails.Login': Cypress.env("admin").login,
		},
	})
	
	cy.loginByForm(Cypress.env('system_admin').login, Cypress.env('system_admin').password, urlkey);
	cy.proxy_from_super_admin(urlkey);
	cy.change_users_password(Cypress.env("admin").login, "123123123");
	cy.request("/Home/Logon?urlkey=" + urlkey);
	cy.glm_login(urlkey, "admin", "123123123")
});

Cypress.Commands.add('set_setting_radio', (urlkey, group, setting, value) => {
	cy.visit('/Administration/Settings?editKey=' + urlkey)
	cy.get("h4:contains(" + group + ")").parent(".panel-heading").click();
	cy.get("tr[id='" + setting + "']").find("td").eq(2).find("a").click();
	cy.get("input[value='" + value + "']").click();
	cy.get("button:contains(OK)").click();
});

Cypress.Commands.add('set_setting_radio_by_form', (foundation_id, setting, value) => {
	cy.request({
		method: 'POST',
		url: '/Administration/UpdateSetting',
		form: true,
		body: {
		 'ElementViewModel.Value': value,
		'Setting.Id': setting,
		'FoundationId': foundation_id,
		},
	  })
});

Cypress.Commands.add('set_setting_features', (urlkey, setting, value) => {
	cy.visit('/Administration/Settings?editKey=' + urlkey)
	cy.get("div[data-target=#FeatureTogglePanel]").click();
	cy.get("td:contain(" + setting + ")").parent("tr").find("td").eq(1).find("a").click();
});

Cypress.Commands.add('add_organization', (name) => {
	cy.visit('/Organization');
	cy.get("a:contains(Add New Organization Manually)").click();
	cy.get("label:contains(Organization Name)").parent("div").find('input[type=text]').type(name, {delay: 0});
	cy.get("button:contains(Save)").click();
});

Cypress.Commands.add('import', (file_name, urlkey) => {
	cy.visit('/Import?editkey=' + urlkey);
	cy.get("input[type=file]").attachFile(file_name);
	cy.get("button[id='ImportTemplateButton']").click();
});

// requires one to already be in the process manager - processes tab
Cypress.Commands.add('activate_process_by_name', (process_name) => {
	cy.activate_by_name(process_name, 6);
});

// requires one to already be in the process manager - universes tab
Cypress.Commands.add('activate_universe_by_name', (universe_name) => {
	cy.activate_by_name(universe_name, 4);
});

Cypress.Commands.add('activate_by_name', (name, tdNum) => {
	cy.intercept("GET", "**/Process/Activate?**").as("activateProcess");
	cy.get("a:contains(" + name + ")").parent("td").parent("tr").find("td").eq(tdNum).find("a").then(($toggle) => {
		if ($toggle.hasClass("Activate")) {
			cy.wrap($toggle).click({force:true});
		}
		cy.wait("@activateProcess");
	})
});

// requires one to already be in the process manager - processes tab
Cypress.Commands.add('deactivate_process_by_name', (process_name) => {
	cy.deactivate_by_name(process_name, 6);
});

// requires one to already be in the process manager - universes tab
Cypress.Commands.add('deactivate_universe_by_name', (universe_name) => {
	cy.deactivate_by_name(universe_name, 4);
});

Cypress.Commands.add('deactivate_by_name', (name, tdNum) => {
	cy.intercept("GET", "**/Process/Deactivate?**").as("deactivateProcess");
	cy.get(`a:contains(${name})`).parent("td").parent("tr").find("td").eq(tdNum).find("a").then(($toggle) => {
		if ($toggle.hasClass("Deactivate")) {
			cy.wrap($toggle).click({force:true});
		}
		cy.wait("@deactivateProcess");
	})
})


Cypress.Commands.add('import_data', (file_name, process_name, urlkey) => {
	cy.visit("/ImportData?editKey=" + urlkey);
	cy.reload();
	cy.get(".processSelectButton").click();
	cy.get("a:contains(" + process_name + ")").click();
	cy.get("input[type=file]").attachFile(file_name);
	cy.get("span[id='ValidateDataFileButton']").click();
	cy.wait(5000)
	cy.get('#ImportStatusPanelBody > span').should('have.class', 'success')
	cy.get("span[id='ImportDataFileButton']").click();
});

Cypress.Commands.add('createProcess', (process_name) => {
	cy.visit({
		method: 'POST',
		url: '/Process/Create',
		form: true,
		body: {
			Name: process_name,
		},
	});
});

Cypress.Commands.add('deleteProcess', (process_id) => {
	cy.request({
		method: 'POST',
		url: '/Process/Delete?processId=' + process_id
	});
});

Cypress.Commands.add('sign_out', (urlkey = Cypress.env('urlkey')) => {
	cy.request("/Home/Logon?urlkey=" + urlkey)
})

Cypress.Commands.add('saveToJSON', (path, requestName, keyVal, first = false) => {
	cy.readFile(path).then(requests => {
		if (first) {
			requests[requestName] = {};
		}
		for (let key in keyVal) {
			requests[requestName][key] = keyVal[key];
		}
		cy.writeFile(path, requests);
	})
})

Cypress.Commands.add('createRequest', (urlkey, requestName, processName, submit = true, saveToJSON = false) => {
	Cypress.log({
		name: 'createRequest',
		message: `${requestName} | ${processName}`,
	})
	let filepath = 'cypress/fixtures/requests.json';
	cy.intercept('POST', '/Request/Action/SaveAnswer').as("saveApplicationAnswer");
	cy.visit('/Process/Apply?urlkey=' + urlkey)
    cy.get("span:contains(" + processName + ")").parent("h4").find("span").eq(2).find("form").find("button:contains(Apply)").click();
	cy.get("input[id='Form_Groups_0__Elements_0__Value']").type(requestName);
	cy.url().then(url => {
		const requestID = url.split("=")[1];
		cy.wrap(requestID).as(requestName);
		if (saveToJSON) {
			cy.saveToJSON(filepath, requestName, {'requestId': requestID}, true);			
		}
	})
	if (saveToJSON) {
		cy.get("#RequestGuid").then($requestGuid => {
			cy.get("#Form_Id").then($formId => {
				cy.get("[data-element-fieldcode='RF_6b86b273ff']").then($elemGuid => {
					let keyVal = {
						'requestGuid': $requestGuid.val(),
						'applicationForm.Id': $formId.val(),
						'Form.Groups[0].Elements[0].Guid': $elemGuid.prop('data-element-guid')
					};
					cy.saveToJSON(filepath, requestName, keyVal);
				})
			})
		})
		
		
	}
	if (submit) {
		cy.get("button:contains(Submit)").click();
		if (saveToJSON) {
			cy.wait("@saveApplicationAnswer").then((intercept) => {
				cy.saveToJSON(filepath, requestName, {'applicationSubmissionId': intercept.response.body.SubmissionId});
			})
		}
	} else {
		cy.get("button:contains(Save)").click();
	}
})

Cypress.Commands.add('completeApplicationFromJson', (requestName) => {
	Cypress.log({
		name: 'completeApplicationFromJson',
		message: `${requestName}`,
	})
	cy.fixture("requests.json").then(requests => {
		cy.request({
			method: 'POST',
			url: '/Request/Submission/Application?request=' + requests[requestName]['requestId'] + '&submission=' + requests[requestName]['applicationSubmissionId'],
			form: true,
			body: {
				"Action": "Complete",
				"Id": requests[requestName]['applicationSubmissionId'],
				"submission":  requests[requestName]['applicationSubmissionId'],
				"RequestId": requests[requestName]['requestId'],
				"RequestGuid": requests[requestName]["requestGuid"],
				"Form.Id": requests[requestName]['applicationForm.Id'],
				"Form.Groups[0].IsThirdPartyGroup": "False",
				"Form.Groups[0].Elements[0].Value": requestName,
				"Form.Groups[0].Elements[0].Guid": requests[requestName]['Form.Groups[0].Elements[0].Guid'],
			},
		})
	})
})

Cypress.Commands.add('approveApplicationFromJson', (requestName, decisionDate, awardType, amountAwarded) => {
	Cypress.log({
		name: 'approveApplicationFromJson',
		message: `${requestName} | ${amountAwarded}`,
	})
	let filepath = 'cypress/fixtures/requests.json';
	const domparser = new DOMParser();
	cy.readFile(filepath).then(requests => {
		// retrieve request data and store it in JSON
		cy.request("/Request/Action/ApproveRequest?request=" + requests[requestName]['requestId']).then(response => {
			let bodyNode = domparser.parseFromString(response.body, "text/html");
			// save decision date
			cy.saveAnswer(requests[requestName]['requestId'], requests[requestName]['approvalSubmissionId'], bodyNode.getElementById("Form_Groups_0__Elements_1__Guid").value, decisionDate);
			// save award type
			cy.saveAnswer(requests[requestName]['requestId'], requests[requestName]['approvalSubmissionId'], bodyNode.getElementById("Form_Groups_0__Elements_2__Guid").value, awardType);
			// save amount awarded
			cy.saveAnswer(requests[requestName]['requestId'], requests[requestName]['approvalSubmissionId'], bodyNode.getElementById("Form_Groups_0__Elements_3__Guid").value, amountAwarded);
			let keyVal = {
				'approvalSubmissionId': bodyNode.getElementById("SubmissionId").value,
				'approvalForm.Id': bodyNode.getElementById("Form_Id").value,
				'approvalForm.StageId': bodyNode.getElementById("StageId").value
			}
			cy.saveToJSON(filepath, requestName, keyVal);
		})
	})
	cy.readFile(filepath).then(requests => {
		// submit approval
		cy.request({
			method: 'POST',
				url: '/Request/Submission/Approval?request=' + requests[requestName]['requestId'] + '&submission=' + requests[requestName]['approvalSubmissionId'],
				form: true,
				body: {
					"Id": requests[requestName]['approvalSubmissionId'],
					"submission":  requests[requestName]['approvalSubmissionId'],
					"RequestId": requests[requestName]['requestId'],
					"RequestGuid": requests[requestName]["requestGuid"],
					"Form.Id": requests[requestName]['approvalForm.Id'],
					"Form.StageId": requests[requestName]['approvalForm.StageId'],
					"Form.Type": "Approval",
					"Action": "Approve"
				},
		})
	})
})

Cypress.Commands.add('saveAnswer', (request, submission, element, value) => {
	Cypress.log({
		name: 'saveAnswer',
		message: `${request} | ${element} | ${value}`,
	})
	cy.request({
		method: 'POST',
		url: '/Request/Action/SaveAnswer',
		form: true,
		body: {
			"Request": request,
			"Submission":  submission,
			"Element": element,
			"Value": value,
		}
	})
})

Cypress.Commands.add('addInstallmentFromJson', (requestName, dueDate, amount = false, count = 1, monthsBetween = "") => {
	Cypress.log({
		name: 'addInstallmentFromJson',
		message: `${requestName} | ${dueDate}`,
	})
	const domparser = new DOMParser();
	let filepath = 'cypress/fixtures/requests.json';
	cy.readFile(filepath).then(requests => {
		cy.request("/Installment/Add/AddInstallments?request=" + requests[requestName]['requestId'] + "&X-Requested-With=XMLHttpRequest&_=" + Date.now()).then(response => {
			let bodyNode = domparser.parseFromString(response.body, "text/html");
			cy.saveToJSON(filepath, requestName, {'InstallmentForms[0].Id': bodyNode.getElementById("InstallmentForms_0__Id").value});
		})
	})
	cy.readFile(filepath).then(requests => {
		cy.request({
			method: 'POST',
				url: '/Installment/Add/AddInstallments',
				form: true,
				body: {
					"Request": requests[requestName]['requestId'],
					"InstallmentForms[0].Id": requests[requestName]['InstallmentForms[0].Id'],
					"InstallmentForms[0].HasDueDate": "True",
					"InstallmentForms[0].HasAmount": "True",
					"InstallmentForms[0].InitialDueDate": dueDate,
					"InstallmentForms[0].AddCount": count,
					"InstallmentForms[0].MonthsBetween": monthsBetween,
				},
		}).then(response => {
			let bodyNode = domparser.parseFromString(response.body, "text/html");
			let requestBody = {
				"[0].Form.Id":  requests[requestName]['InstallmentForms[0].Id']
				}
			bodyNode.querySelectorAll("input").forEach(input => {
				if (input.hasAttribute('name')) {
					requestBody[input.getAttribute('name')] = input.value;
				}
			})
			if (amount) {
				requestBody['[0].Form.Groups[0].Elements[1].Value'] = amount;
			}
			cy.request({
				method: 'POST',
					url: '/Installment/Add/SaveInstallments',
					form: true,
					body: requestBody,
			})
		})
	})
})

Cypress.Commands.add('inviteCollaborator', (requestID, collabEmail, message, permissions = "CanEdit", ) => {
	cy.visit("/Request/Submission/Application?request=" + requestID);
	cy.get('#HeaderButtons > a.btn.btn-primary:contains(Collaborate)').click();
			cy.get('#form0 > div.modal-header > h4').should('be.visible');
			cy.get('#InviteEmail').should('be.visible').type(collabEmail, {delay:0});
			cy.get("input[type='radio'][name='Permissions'][value='" + permissions + "']").click();
			cy.get('#Message').type(message, {delay:0});
			cy.get("#form0 > div.modal-footer > button.btn.btn-primary.pull-right").eq(1).click();
})

Cypress.Commands.add('assignDefaultEvaluatorTo', (requestName) => {
	cy.visit("/Workload/List/Application?active=Submitted");
        cy.get('#SearchBox').type(requestName, {delay: 0});
        cy.get('#ApplicationSubmitted > tbody > tr > td:nth-child(9) > a').first().click();
        cy.get('button.btn.btn-primary:contains(Application Complete)').click();
        cy.get('a.btn.btn-primary:contains(Assign / View Evaluators)').click();
        cy.get('#Evaluation1 > div > div > table > thead > tr > th:nth-child(1) > div > input[type=checkbox]').click();
        cy.get('button.btn.btn-primary.pull-right:contains(Save)').click();
        cy.get('#EvaluationSelectionResultModal > div > div > div.modal-header > h4').should('contain', 'Evaluators Saved');
        cy.get('#EvaluationSelectionResultModal > div > div > div.modal-footer > div > button:contains(Close)').click();
})
Cypress.Commands.add('archiveRequest', (request_name_substring) => {
	cy.visit('/Process');
	cy.get('#Available > div > ul > li:nth-child(2) > a').click();
	cy.get("a").contains(request_name_substring).parent("td").parent("tr").find("td").eq(6).find("a").then(($toggle) => {
		if ($toggle.hasClass("Deactivate")) {
			cy.wrap($toggle).click({force:true});
		}
	})
	cy.get("a").contains(request_name_substring).parent("td").parent("tr").find("td").eq(1).find("input[type='checkbox']").click();
	cy.get("#Processes").find(".panel-footer").find(".dropdown-toggle").should("contain", "Batch Actions").click();
	cy.get("#Processes").find("button[name='BatchAction'][value='Archive']").click();
});

Cypress.Commands.add('archiveUniverse', (universe_name_substring) => {
	cy.intercept("/Process/Deactivate?*").as("deactivateUniverse");
	cy.visit('/Process');
	cy.get("#SearchBox").type(universe_name_substring.slice(universe_name_substring.length - 4), {delay:0});
	cy.get("a").contains(universe_name_substring).parent("td").parent("tr").find("td").eq(4).find("a").then(($toggle) => {
		if ($toggle.hasClass("Deactivate")) {
			cy.wrap($toggle).click({force:true});
		}
	})
	cy.wait("@deactivateUniverse");
	cy.get("a").contains(universe_name_substring).parent("td").parent("tr").find("td").eq(0).find("input[type='checkbox']").click();
	cy.get("#Universes").find(".panel-footer").find(".dropdown-toggle").should("contain", "Batch Actions").click();
	cy.get("#Universes").find("button[name='BatchAction'][value='Archive']").click();
});

Cypress.Commands.add('addNewQuestion', (type, label, instructions, paramOptions) => {
	
	let defaultOptions = {
		isUniverse: false,
		parseSpecialCharSequencesVal: true,
		visibility: "Everyone",
		required: "Optional",
		maxLength: null,
		items: null,
		leftDigit: null,
		rightDigit: null,
		min: null,
		max: null,
		maxFileSize: null,
		allowedFileType: null,
	}

	const options = Object.assign(defaultOptions, paramOptions);
	
	cy.intercept('POST', '**/Form/Update/UpdateElement**').as('updateQuestion');
	cy.intercept('GET', '**/Form/Update/AddElement?**').as('addNewQuestionFormOpens');
	cy.intercept('GET', '**/Form/Update/UpdateElement?**').as('addNewFormOpens');

	cy.get('button:contains(Add New Question)').last().click();
	cy.wait("@addNewQuestionFormOpens");
	cy.get('#ElementAddModal').find("a").contains(type).click();
	cy.wait("@addNewFormOpens");
	cy.get("#form0 > .modal-body").find('#Label').type(label, {parseSpecialCharSequences: options.parseSpecialCharSequencesVal, delay:0});
	cy.get("div.fr-element").type(instructions, {parseSpecialCharSequences: options.parseSpecialCharSequencesVal, delay:0});
	if (options.maxLength) {
		cy.get("#form0 > .modal-body").find('#MaxTextLength').type(options.maxLength, {delay:0});
	}
	if (options.visibility != "Everyone") {
		cy.get("#form0 > .modal-body").find('#DisplayType').select(options.visibility);
	}
	if (options.required != "Optional") {
		cy.get("#form0 > .modal-body").find('#RequiredType').select(options.required);
	}
	if (options.items) {
		options.items.forEach(item => {
			cy.get("#ListItemsInput").type(item + "{enter}");
		})
	}
	if (options.leftDigit && options.rightDigit) {
		cy.get("#DecimalLeftDigits").clear().type(options.leftDigit);
		cy.get("#DecimalRightDigits").clear().type(options.rightDigit);
	}
	if (options.min && options.max) {
		cy.get("#Min").type(options.min);
		cy.get("#Max").type(options.max);
	}
	if (options.maxFileSize) {
		cy.get("#MaxFileSize").type(options.maxFileSize);
	}
	if (options.allowedFileType) {
		cy.get("#AllowedFileTypes").type(options.allowedFileType);
	}
	cy.get('button:contains(Save Question)').click();
	cy.wait("@updateQuestion");
})

// must be at process stage beforehand
Cypress.Commands.add('setEmailsInProcessManager', (listOfTemplates) => {
    cy.intercept('GET', '**/Process/_ProcessStatus**').as("updateProcessStatus");
	for (let i = 0; i < listOfTemplates.length; i++) {
		cy.get(".tab-pane.active").find(".tab-pane.active").find("select.EmailTemplateDropDown").eq(i).select(listOfTemplates[i]);
		cy.wait('@updateProcessStatus');
	}
})
//Starts on the update process page
//formType Eligibility, LOI, Application, Evaluation 1, Evaluation 2, Installment, Follow Up
Cypress.Commands.add('createNewForm', (formType) => {
	if (formType.includes('Follow Up')) {
		cy.get(".stage-block:contains(Follow Ups)").should('be.visible').click();
		cy.get("#AddFollowUp").click();
		cy.get("a:contains(Create New Form)").click();
		cy.get("button:contains(Create New Form)").click();
	}
	if (formType.includes('Eligibility')) {
		cy.get(".stage-block:contains(Eligibility)").should('be.visible').click();
		cy.get("a:contains(Add Eligibility Form)").click();
		cy.get("a:contains(Create New Form)").click();
		cy.get("button:contains(Create New Form)").click();
	}
	if (formType.includes('Evaluation 1')) {
		cy.get(".stage-block:contains(Application)").should('be.visible').click();
		cy.get(".FormButton[data-form-type='Evaluation']").eq(0).click({ force: true });
		cy.get("a:contains(Create New Form)").click();
		cy.get("button:contains(Create New Form)").click()
	}
	if (formType.includes('Evaluation 2')) {
		cy.get(".stage-block:contains(Application)").should('be.visible').click();
		cy.get(".FormButton[data-form-type='Evaluation']").eq(1).click({ force: true });
		cy.get("a:contains(Create New Form)").click();
		cy.get("button:contains(Create New Form)").click()
	}
	if (formType.includes('Application')) {
		cy.get(".stage-block:contains(Application)").should('be.visible').click();
		cy.get(".FormButton[data-form-type='Application']").click({ force: true });
		cy.get("a:contains(Create New Form)").click();
		cy.get("button:contains(Create New Form)").click()
	}
	if (formType.includes('LOI')) {
		cy.get(".stage-block:contains(LOI)").should('be.visible').click();
		cy.get(".FormButton[data-form-type='LOI']").click({ force: true });
		cy.get("a:contains(Create New Form)").click();
		cy.get("button:contains(Create New Form)").click()
	}
	if (formType.includes('Installment')) {
		cy.get(".stage-block:contains(Decisions)").should('be.visible').click();
		cy.get("#AddInstallmentFormButton").click();
		cy.get("a:contains(Create New Form)").click();
		cy.get("button:contains(Create New Form)").click();
	}
})
Cypress.Commands.add('actAsCollaborator', (permission, requestName) => {
	cy.visit('/Search/Requests');
	cy.get('#RequestsSearch > div.panel-footer.clearfix > button').click();
	cy.get("#ProjectName").type(requestName);
	cy.get('#SearchRequestButton').click();
	cy.get("#RequestsTable > div > table > tbody > tr > td > a").eq(2).first().click();
	cy.get("a:contains(Request Email History)").click();
	cy.get('a:contains(Invitation to Collaborate)').click();
	cy.get('a:contains(here)').invoke('removeAttr', 'target').click();
	cy.get('#FirstName').type(requestName);
	cy.get('#LastName').type(requestName);
	cy.get('#Password').type(requestName);
	cy.get('body > div.container > div.RegisterForm > form > div > div.panel-footer.clearfix > button').click();
	cy.get('body > div.container > div.rb-container > nav > ul > li:nth-child(2)').click();
	cy.get('a:contains(Edit Application)').click();
	if (permission == "CanView") {
		cy.get('button:contains(Save Application)').should('not.to.exist');
		cy.get('button:contains(Submit Application)').should('not.to.exist');
	} else {
		cy.get('#Form_Groups_0__Elements_0__Value').type('Collaborator ' + permission + requestName);
		cy.get('button:contains(Save Application)').click();
		if (permission == "CanEdit") {
			cy.get('button:contains(Submit Application)').should('not.exist')
		} else if (permission == "CanSubmit") {
			cy.get('button:contains(Continue)').click();
			cy.get('button:contains(Submit Application)').click();
			cy.get(".success").should('contain', 'Your Application has been submitted.');
		}
	}
})
/* Must already be logged in as SuperAdmin
   stage param needs to be "Qualification", "LoiEvaluation", or "Evaluation2"
   toggleVal param must be "ON" or "OFF" */
Cypress.Commands.add('manageProcessStages', (urlkey, processName, stage, toggleVal) => {
	let stageToggleSelector = ".AddRemove" + stage + "Button";
	cy.visit("/Process/ProcessStageManager?editkey=" + urlkey);
	cy.get("#Available").find("td").contains(processName).eq(0).parent().find(stageToggleSelector).then(($toggle) => {
		if (toggleVal != $toggle.attr('data-original-title')){
			cy.wrap($toggle).click();
		}
	})
})
// applies quick export command and asserts its functionality when in search pages (requests, payment tracking, users, orgs)
Cypress.Commands.add('quickExportFromSearch', (containerSelector, quickExportButtonId, batchWording) => {
	cy.intercept("POST", "/DataSet/*QuickExport").as("downloadFile");
	cy.get(containerSelector).then($container => {
		if ($container.find("input[type='checkbox'][data-check-all='initialized'][disabled]").length == 0) {
			cy.wrap($container).find("input[type='checkbox'][data-check-all='initialized']").click();
			if (quickExportButtonId && batchWording) {
				cy.wrap($container).find("button[type='button']").contains(batchWording).click();
				cy.wrap($container).find("#" + quickExportButtonId).click();
			} else {
				cy.get("button[type='button']").contains("Quick Export").click();
			}
			cy.wait("@downloadFile").then(response => {
				expect(response.response.headers['content-disposition']).to.include("Attachment").and.to.include("data.csv");
			});
			cy.contains("Problem Generating Quick Export").should("not.exist");
		}
	});
})

//Must be logged in as admin
//action param must be: "approved", "completed", "denied", "draft"
//user param is taken from the last name link to that user's user summary page
//process param must be: "Ghost Process Dummy - Imported", "Configured Process - Imported"
Cypress.Commands.add('createManualRequests', (action, user, process) => {
	cy.visit("/User");
	cy.get('[type="checkbox"]').check('4')
	cy.get("button:contains('Search')").click();
	
	cy.get('a:contains("' + user +'")').click();

	cy.get("li:contains('Request History')").click();
	cy.get("a:contains('Create Request')").click();

	cy.get('#SelectedProcessId').select(process);
	cy.get("button:contains('Continue')").click();

	cy.get('#Form_Groups_0__Elements_0__Value').clear().type('Manual Grant' + Date.now());

	switch(action){
		case "approved":
			cy.get("button:contains('Approve Request')").click();

			cy.get('#Form_Groups_0__Elements_2__Value').select("One Time");
			
			cy.get('#Form_Groups_0__Elements_3__Value').clear().type(1000);
			cy.get("button:contains('Approve Request')").click();
			
			cy.get('#InstallmentForms_0__InitialDueDate').clear().type('12/31/9999');
			cy.get("button:contains('Add Installments')").click();
			cy.get("button:contains('Save Installments')").click();

			//check if stage is "Complete" and decision is "One Time"
			cy.get("#RequestTabs").find("li:contains('Request')").click();
			cy.get('#StageTable').contains('td', 'Complete');
			cy.get('#DecisionStageTable').contains('td', 'One Time');
			break;
		case "completed":
			cy.get("button:contains('Application Complete')").click();

			//check if the stage is "Complete"
			cy.get("#RequestTabs").find("li:contains('Request')").click();
			cy.get('#StageTable').contains('td', 'Complete');
			break;
		case "denied":
			cy.get("button:contains('Deny Request')").click();
			cy.get("button:contains('Deny Request')").click();
			
			//check if decision type is 'Denied'
			cy.get("#RequestTabs").find("li:contains('Request')").click();
			cy.get('#DecisionStageTable').contains('td', 'Denied');
			break;
		case "draft":
			cy.get("button:contains('Save Application')").click();
			cy.get("button:contains('Continue')").click();
			//check if stage is 'Draft'
			cy.get("#RequestTabs").find("li:contains('Request')").click();
			cy.get('#StageTable').contains('td', 'Draft');
			break;
	}
});

Cypress.Commands.add('importOrganizationInSetup', (urlkey) => {
	cy.intercept("POST", "**/Migration/Append/ValidateAddOrgAppend**").as("validateImport");
	cy.loginByForm(Cypress.env('system_admin').login, Cypress.env('system_admin').password, urlkey);
	cy.visit('/Migration/Append?editkey=' + urlkey)
	cy.get('a:contains(Add Organizations)').click();
	cy.get("input[type=file]").attachFile('Organizations.xlsx');
	cy.get('button:contains(Validate)').eq(1).click();
	cy.wait("@validateImport");
	cy.get('#AddOrgResults').then(($text) => {
	if(!$text.text().includes('ERROR')) {
		cy.get('#UploadOrgs').click();
		cy.get('#AddOrgSuccessPanel:contains(Data has been uploaded)').should('be.visible');
	}
	})
})

Cypress.Commands.add('importEmailTemplatesInSetup', (urlkey) => {
	cy.intercept("POST","**/Import/FinishTemplateFileSetup**").as("finishTemplateSetup");
	cy.intercept("POST","**/Import/ImportTemplateFile**").as("importTemplateFile");

	cy.loginByForm(Cypress.env('system_admin').login, Cypress.env('system_admin').password, urlkey);
	cy.proxy_from_super_admin(urlkey);
	cy.visit("/Email");
	cy.get("#Available").then(($text) => {
	if ($text.text().includes("Please add an email template")) {
		cy.request("/User/Index/UnProxyAsUser?unSetFoundation=True");
		cy.visit('/Import?editkey=' + urlkey);
		cy.get("#TemplateFileUpload").find("input[type=file]").attachFile('EmailTemplates.xml');
		cy.wait("@finishTemplateSetup");
		cy.get("#ImportTemplateButton").click();
		cy.wait("@importTemplateFile");
	}
	})
})

Cypress.Commands.add('addUsersInSetup', (urlkey, filename) => {
	cy.intercept("POST", "**/Migration/Append/ValidateAddActorAppend**").as("validateImport");

	cy.loginByForm(Cypress.env('system_admin').login, Cypress.env('system_admin').password, urlkey);  
	cy.visit('/Migration/Append?editkey=' + urlkey)
	cy.get('a:contains(Add Users)').click();
	cy.get("input[type=file]").attachFile(filename + '.xlsx');
	cy.wait(2000);
	cy.get('button:contains(Validate)').eq(3).click();
	cy.wait("@validateImport");
	cy.get('#AddActorResults').then(($text1) => {
	if (!$text1.text().includes('ERROR')) {
		cy.get('#UploadActors').click();
		cy.get('#AddActorSuccessPanel:contains(Data has been uploaded)').should('be.visible')

		cy.loginByForm(Cypress.env('admin').login, Cypress.env('admin').password, urlkey)
		cy.change_users_password(Cypress.env("applicant").login, "Test1234567890!");
		cy.change_users_password(Cypress.env("board_member").login, "Test1234567890!");
		cy.change_users_password(Cypress.env("staff_evaluator").login, "Test1234567890!");
		cy.create_new_user(Cypress.env('grant_manager').first_name, Cypress.env('grant_manager').last_name, Cypress.env('grant_manager').login, undefined, "Test1234567890!", ['GrantsManager'])
		cy.glm_login(urlkey, 'applicant', "Test1234567890!")
		cy.glm_login(urlkey, 'board_member', "Test1234567890!")
		cy.glm_login(urlkey, 'staff_evaluator', "Test1234567890!")
		cy.glm_login(urlkey, 'grant_manager', "Test1234567890!")
	}
	})     
})

Cypress.Commands.add('importProcessesInSetup', (urlkey) => {
	cy.loginByForm(Cypress.env('system_admin').login, Cypress.env('system_admin').password, urlkey);
	cy.proxy_from_super_admin(urlkey);
	cy.request('/Process').then(response => {
	if (response.body.includes("Please add a process")) {
		cy.loginByForm(Cypress.env('system_admin').login, Cypress.env('system_admin').password, urlkey);

	cy.import("ThirdPartyProcess.xml", urlkey);
	cy.import("RestrictedProcess.xml", urlkey);
	cy.import("GhostProcessDummy.xml", urlkey);
	cy.import("ExampleProcess.xml", urlkey);
	cy.import("SecondProcess.xml", urlkey);
	cy.import("ConfiguredProcess.xml", urlkey);
	cy.import("LOIProcess.xml", urlkey);
	cy.import("UniverseProcess.json", urlkey); //This works if the enhance process importer is set correclty
	cy.import("UACypress.json", urlkey); //This works if the enhance process importer is set correclty

	cy.proxy_from_super_admin(urlkey);
	cy.visit('/Process');
	cy.activate_universe_by_name("Preview Filter Test");
	cy.activate_universe_by_name("UA Cypress Test")
	cy.activate_universe_by_name("UA Configured - Imported")

	cy.get('a:contains(Processes)').first().click();
	cy.activate_process_by_name("Example Process");
	cy.activate_process_by_name("Second Process");
	cy.activate_process_by_name("Third Party Process");
	cy.activate_process_by_name("Ghost Process Dummy");
	cy.activate_process_by_name("Ghost Process Restricted");
	cy.activate_process_by_name("Configured Process");
	cy.activate_process_by_name("LOI Process");
	}
	});
})
Cypress.Commands.add('addEligibilityGroupUA', (ruleGroup) => {
	Cypress.log({
		name: 'addEligibilityGroupUA',
		message: `${ruleGroup.name}`,
	})
	cy.get("#Eligibility").find("button").contains("Add Eligibility Rule Group").click();
	cy.get("input[name='Eligibility.EditingRuleGroup.Name']").clear().type(ruleGroup.name);
	cy.get("div.EligibilityRule").find("select").eq(0).select(ruleGroup.question);
	cy.get("div.EligibilityRule").find("select").eq(1).select(ruleGroup.comparator);
	cy.get("div.EligibilityRule").find("input").type(ruleGroup.rule);
	if (ruleGroup.opportunity) {
		cy.get("[data-rb-tab='#EligibilityOpportunities']").click();
		cy.get("#EligibilityOpportunities").find("label").contains("Common").find("input[type='checkbox']").click();
		cy.get("#EligibilityOpportunities").find("td").contains(ruleGroup.opportunity).siblings().find("input[type='checkbox']").click();
	}
	cy.get("#AddEligibility-Wizard").find("button").contains("Save Rule Group").click();
})

Cypress.Commands.add('deleteAllEligibilityGroupsUA', (universeName) => {
	Cypress.log({
		name: 'Deleting UA Eligibility Groups',
	})
	cy.intercept("/Universe/Update?process*").as("loadUniverse");
	cy.visit("/Process");
	cy.get("#Universes").find("a").contains(universeName).first().then($elem => {
		cy.visit($elem.attr('href'));
	})
	cy.wait("@loadUniverse");
	cy.get("#process").then(universe => {
		cy.get("#Eligibility").then($container => {
			if ($container.find("div.EligibilityHeader > label").length > 0) {
				cy.wrap($container).find("div.EligibilityHeader > label:nth-child(1)").each((ruleName => {
					let opportunity = ruleName.text().split("_")[0]
					cy.deleteSingleEligibilityGroupUA(ruleName.text(), opportunity, universe)
				}))
			}
		})
	})
})
Cypress.Commands.add('deleteSingleEligibilityGroupUA', (ruleName, opportunity, universe) => {
	Cypress.log({
		name: 'Deleting',
		message: `${ruleName}`,
	})
	if (opportunity == "Common") {
		opportunity = "All Opportunities";
	}
	cy.get("#Opportunity > option").contains(opportunity).then(oppID => {
		cy.get("#Eligibility").find("label").contains(ruleName).siblings("label.EligibilityType").find("a[title='Edit Rule Group']").then(ruleGroupID => {
			let requestPayload = {"ruleGroup":ruleGroupID.attr('id'),"universe":universe.val()}
			if (opportunity != "All Opportunities") {
				requestPayload['opportunities'] = [oppID.val()];
			}
			cy.request({
				method: 'POST',
				url: '/Universe/Update/DeleteEligibilityGroup',
				body: requestPayload,
				failOnStatusCode: false
			})
		})
	})
})

Cypress.Commands.add('setQuestionToOpportunity', (questionName, opportunityName) => {
	cy.intercept("POST", "/Form/Update/UpdateElement").as("updateQuestion");
	cy.get("label").contains(questionName).parent().siblings("div.ElementUpdateActions").first().find("form[data-ajax-update='#EditPlaceholder'] > button").click();
	cy.get("#EditElementModal").find("[data-rb-tab='#Opportunities']").click();
	
	cy.get("#OpportunitiesTable").then($container => {
		if ($container.find("input.disabled").length > 0) {
			cy.get("#IsCommonQuestion").click();
		}
	})
    cy.get("#OpportunitiesTable").find("td").contains(opportunityName).first().siblings("td").first().find("input[type='checkbox']").click();
	cy.get("#EditElementModal").find("button[type='Submit']").contains("Save Question").click();
	cy.wait("@updateQuestion");
})

Cypress.Commands.add('setFollowUpToOpportunity', (opportunityName) => {
	cy.get("a[data-rb-modal-open='#EditFollowUp-Wizard']").click();

	cy.get("#EditFollowUpOpportunities").then($container => {
		if ($container.find("input[disabled]").length > 0) {
			cy.get("#EditFollowUpOpportunities").find("label").contains("Common").find("input[type='checkbox']").click();
		}
	})
	if (opportunityName == "Common") {
		cy.get("#EditFollowUpOpportunities").find("label").contains(opportunityName).find("input[type='checkbox']").click();
	} else {
		cy.get("#EditFollowUpOpportunities").find("td").contains(opportunityName).first().siblings("td").first().find("input[type='checkbox']").click();
	}
	cy.get("#EditFollowUp-Wizard").find("button[type='button']").contains("Save Selections").click();
})

Cypress.Commands.add('resetQuestionsToCommon', (questions) => {
	cy.intercept("POST", "/Form/Update/UpdateElement").as("updateQuestion");

	questions.forEach(question => {
		cy.get("label").contains(question).parent().siblings("div.ElementUpdateActions").first().find("form[data-ajax-update='#EditPlaceholder'] > button").click();
		cy.get("#EditElementModal").find("[data-rb-tab='#Opportunities']").click();
		cy.get("#OpportunitiesTable").then($container => {
			if ($container.find("input.disabled").length == 0) {
				cy.get("#IsCommonQuestion").click();
				cy.get("#EditElementModal").find("button[type='Submit']").contains("Save Question").click();
				cy.wait("@updateQuestion");
			} else {
				cy.get("#EditElementModal").find("button").contains("Cancel").click();
			}
		})
		
	})
})

Cypress.Commands.add('addUAInstallment', (installment) => {
	cy.intercept("POST", "/Universe/Update/SaveInstallment").as("saveInstallment");

	cy.get("#Decisions").find("button").contains("Add Installment").click();
	cy.get("#SelectInstallment").find("input[value='New']").click();
	cy.get("#SelectInstallment").find("input[value='New Installment']").clear().type(installment.name, {delay:0});
	if (installment.opps != "Common") {
		cy.get("#AddInstallment-Wizard-Form").find("[data-rb-tab='#InstallmentOpportunities']").click();
		cy.get("#InstallmentOpportunities").find("label").contains("Common").find("input").click();
		installment.opps.forEach((opportunity) => {
			cy.get("#InstallmentOpportunities").find("td").contains(opportunity).siblings().find("input").click();
		})
	}
	cy.get("#AddInstallment-Wizard").find("button").contains("Use Selected Form").click();
	cy.wait("@saveInstallment");
})

Cypress.Commands.add('addCommittee', (name, members, showApplicantInfo = false) => {
	Cypress.log({
		name: 'addCommittee',
	})
	cy.intercept("/Committee/Create").as("createCommittee");
	cy.intercept("/Committee/Update/Suggest?committee=*").as("suggestCommittee");
	cy.intercept("/Committee/Update/AddMember?*").as("addCommittee");
	cy.visit("/Committee");
	cy.get("#HeaderButtons").find("a").contains("Add New Committee").click();
	cy.wait("@createCommittee");
	cy.get("#Groups_0__Elements_0__Value").type(name);
	cy.get("button").contains("Save").click();
	if (showApplicantInfo) {
		cy.get("label").contains("Show Applicant Info").next("a[data-original-title='Toggle On/Off']").click();
	}
	members.forEach(member => {
		cy.get("#searchText").type(member);
		cy.wait("@suggestCommittee");
		cy.get("#ui-id-1").click();
		cy.wait("@addCommittee");
	});
	cy.get("button").contains("Save").click();
})

Cypress.Commands.add('addBeforeHookUARequests', (urlkey, type, status, opportunities, rules) => {
	Cypress.log({
		name: 'addBeforeHookUARequests',
	})
	let baseName = opportunities[0].slice(0, -1);
	cy.intercept("/Workload/List/ApplicationJsonData?table=" + type + status).as(type + status + "Loaded")
	cy.visit("/Workload/List/" + type + "?active=" + status);
	cy.get("#SearchBox").type(baseName);
	cy.wait("@" + type + status + "Loaded");
	
	// checks if 3 Opp requests are already set, if they're all not there it adds them
	cy.get("#ApplicationComplete").then($container => {
		var allOppsExist = true;
		opportunities.forEach(opp => {
			allOppsExist = allOppsExist && $container.text().indexOf(opp) >= 0;
		})
		var noMatches = $container.text().indexOf('No matching records found') >= 0 || $container.text().indexOf('No data available in table') >= 0;
		var correctLength = $container.find("tbody > tr").length == opportunities.length;

		if (noMatches || !allOppsExist || !correctLength) {
			
			// if there is some, but not all 3, of the requests then it abandons them all first
			if (!noMatches) {
				cy.get("#ApplicationComplete").find("thead").find("input[type='checkbox'][data-check-all='initialized']").click();
				cy.get("#ApplicationComplete_wrapper").find("button").contains("Batch Options").click();
				cy.get("#MarkAbandoned").click({force:true});
				cy.get("#uiAlert").find("button").contains("OK").click();
			}
			cy.sign_out(urlkey);

			// creates requests
			cy.loginByForm(Cypress.env('applicant').login, Cypress.env('applicant').password, urlkey);
			cy.visit("/Process/Apply?urlkey=" + urlkey);
			cy.get("#SearchBox").type("Configured");
			cy.get("span").contains("UA Configured - Imported").parent().find("span.HeaderApplyButton").click();
			for (let i = 0; i < rules.length; i++) {
				cy.get("#Form_Groups_0__Elements_" + i + "__Value").type(rules[i]);
			}
			cy.get("button").contains("Submit Application").click();
			cy.sign_out(urlkey);

			if (status == "Complete") {
				// marks them complete
				cy.loginByForm(Cypress.env('admin').login, Cypress.env('admin').password, urlkey);
				cy.visit("/Workload/List/" + type + "?active=Submitted");
				cy.get("#SearchBox").type(baseName);
				cy.intercept("POST", "/Background/MarkComplete").as("markComplete")
				cy.get("#ApplicationSubmitted").find("thead").find("input[type='checkbox'][data-check-all='initialized']").click();
				cy.get("#ApplicationSubmitted_wrapper").find("button").contains("Batch Options").click();
				cy.get("#MarkComplete").click({force:true});
				cy.get("#uiAlert").find("button").contains("OK").click();
				cy.wait("@markComplete")
				cy.get("#CompleteModal").find("button").contains("OK").click();
			}
		}
	})
})

Cypress.Commands.add('batchAssignEvaluators', (requestNameOrOppName) => {
	Cypress.log({
		name: 'batchAssignEvaluators',
	})
	cy.intercept("POST", "/Evaluation/SaveEvaluators*").as("saveEvaluators");
	cy.get("#ApplicationComplete").find("tr:contains('" + requestNameOrOppName + "')").find("td > input[type='checkbox']").check();
	cy.get("#ApplicationComplete").find("button").contains("Batch Options").click();
	cy.get("#AssignEvaluators").click();
	cy.get("#EvaluationSelectionModal").find("#Evaluation1").find("input[type='checkbox'][data-check-all='initialized']").check();
	cy.get("#EvaluationSelectionModal").find("button").contains("Save").click();
	cy.wait("@saveEvaluators");
	cy.wait(300)
	cy.get("#EvaluationSelectionResultModal").find("button").contains("Close").click({force:true});
})

// assumes you are already in the request summary page if a url isn't passed
Cypress.Commands.add('revertStatus', (url = null) => {
	Cypress.log({
		name: 'revertStatus',
	})
	cy.intercept("/Request/Action/ChangeStatus*").as("changeRequestStatus");
	if (url) {
		cy.visit(url);
	}
	cy.get("#RequestStatus").find("div.panel-heading").contains("Advanced Options").click();
	cy.get("#AdvancedOptionsContent").find("a").contains("Revert Status").click();
	cy.get("#uiAlert").find("button").contains("OK").click();
	cy.wait("@changeRequestStatus");
})

//CSuite ================================================================================================

Cypress.Commands.add('csuite_login', (logon,password) =>
{
     cy.visit('/erp');
     cy.get("input[name*='login']").type(logon);
     cy.get("input[name*='passwd']").type(password);
     cy.get("input[value*=Login]").click();
});

Cypress.Commands.add('createngagementstrategy', (name) =>
{
     cy.get("a:contains(Profiles)").click();
     cy.get("span:contains('Profile Types')").click();
     cy.get("span:contains('Add Engagement Strategy')").click();
     cy.get("input[name$='::name']").type(name);
     cy.get("input[value=Save]").click();
});

Cypress.Commands.add('createsteward', (value) =>
{
     cy.get("a:contains(Home)").click();
     cy.get("a:contains(Steward)").click();
     cy.get("span:contains('Add Stewards')").click();
     cy.get("input[value=" + value + "]").click();
     cy.get("input[value='Create Stewards']").click();
});

Cypress.Commands.add('deleteSteward', (value) =>
{
     cy.get("a:contains(Home)").click();
     cy.get("a:contains(Steward)").click();
     cy.get("a[href='/erp/steward/delete?employee_id=" + value + "']").click();
	 cy.get("a:contains(Yes)").click();
});

Cypress.Commands.add('getIframeBody', () => {
	return cy.get('iframe').its('0.contentDocument.body').should('not.be.empty').then(cy.wrap);
});

Cypress.Commands.add('createDonation', (mInternalDonationProfile, mInternalDonationDescription,mInternalDonationAmount,mInternalDonationFund, tribute) => {
	cy.get("a:contains('Home')").click();
			cy.get("a:contains('Donations')").eq(0).click();
			cy.get("a:contains('Create')").eq(0).click();
			cy.get("input[id='search']").type(mInternalDonationProfile);
			cy.get("li:contains(" + mInternalDonationProfile + ")").click();
			cy.get(".calendar").click({force:true});
			cy.get(".ui-state-highlight").click();
			cy.get("input[name$='donation_date']").then((date) => {
				var mInternalDonationSlashed  = date.val();
				cy.get("input[name$='description']").type(mInternalDonationDescription);
				cy.get("input[name$='amount']").type(mInternalDonationAmount);
				cy.get("th:contains(Destination Fund)").parent("tr").find("td").find("input[data-widget]").type(mInternalDonationFund);
				cy.get("li:contains(" + mInternalDonationFund + ")").click();
				cy.get("input[name='payment_method_id']").eq(1).click();
				if(tribute)
				{
					cy.get("input[value='memory']").click();
					cy.get("input[name$='::memorial_name']").type("Dead Person");
				}
				cy.get("input[value='Process']").click();

				
				cy.get("th:contains(Created)").parent("tr").find("td").should(($created) => {
					expect($created).to.contain(mInternalDonationSlashed);
				});
				cy.get("th:contains(Donation Date)").parent("tr").find("td").should(($donation_date) => {
				    expect($donation_date).to.contain(mInternalDonationSlashed);
				});
				cy.get("th:contains(Donor)").parent("tr").find("td").find("a").eq(0).should(($donor) => {
				    expect($donor).to.contain(mInternalDonationProfile);
				});
				cy.get("th:contains(Description)").parent("tr").find("td").should(($description) => {
				    expect($description).to.contain(mInternalDonationDescription);
				});
				cy.get("th:contains(Fund)").parent("tr").parent("thead").parent("table").find("tbody").find("tr").find("td").eq(0).find("a").should(($fund) => {
				    expect($fund).to.contain(mInternalDonationFund);
				});
				cy.get("th:contains(Amount)").parent("tr").find("td").should(($amount) => {
				    expect($amount).to.contain(mInternalDonationAmount);
				});
				
				cy.get("span:contains(Post)").parent("a").click();
				cy.get("a:contains('Home')").click();
            	cy.get("a:contains('Till')").eq(0).click();
				cy.get("a:contains('Deposit To Bank')").click();
			
				cy.get("option:contains(Checking)").eq(0).then(($option) => {
					cy.get("select").select($option.val());
					cy.get("th:contains(Deposit Date)").parent("tr").find("td").find("button").click();
					cy.get(".ui-state-highlight").click();
					cy.get("[id='allcheck']").click();
					cy.get("input[type='submit']").click();
					cy.get("td:contains(Check)").should("be.visible");
					cy.get("td:contains(" + mInternalDonationFund + ")").should("be.visible");
					cy.get("td:contains(" + mInternalDonationProfile + ")").should("be.visible");
					cy.get("td:contains(" + mInternalDonationAmount + ")").should("be.visible");
				});
			});
});

Cypress.Commands.add('createFund', (fundName, groupName, accountName, hasBudget) => {
	cy.get("a:contains(Home)").click();
	cy.get("a:contains(Funds)").eq(0).click();
	cy.get("a[href='/erp/funit/create']").click();
	cy.get("input[name$='::name']").type(fundName);
	cy.get("select[name$='::fgroup_id']").select(groupName);
	cy.get("select[name$='::cash_account_id']").select(accountName);
	if(hasBudget)
	{
		cy.get("input[name$='::budget']").click();
	}
	cy.get("input[value=Create]").click();
	cy.wait(2000);
});

Cypress.Commands.add('transferFunds', (fundId, transferFund,amount) => {
	cy.get("a:contains(Home)").click();
	cy.wait(2000);
	cy.get("a:contains(Funds)").eq(0).click();
	cy.get("span:contains(List)").eq(0).click();
	cy.get("a:contains(" + fundId + ")").click();
	cy.get("a:contains(transfer)").click();
	cy.get("a:contains(Switch to Interfund Transfer)").click();
	cy.wait(2000);
	cy.get("input[data-search-value='to_funit_id']").type(transferFund);
	cy.get("div:contains(" + transferFund +")").click();
	cy.get(".calendar").click({force:true});
	cy.get(".ui-state-highlight").click();
	cy.get("input[name$='::description']").type("test");
	cy.get("input[name$='::amount']").type(amount);
	cy.get("input[value=Transfer]").click();
});