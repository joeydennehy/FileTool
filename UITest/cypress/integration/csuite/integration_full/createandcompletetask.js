describe('Full Test', ()=> {
	context("Create and Complete Task", () => {
		it("Create and Complete Task Test", () => {
			cy.csuite_login(Cypress.env("CS_USER"), Cypress.env("CS_PASSWORD"));
			cy.wait(2000);
			cy.get("a:contains(Tasks)").click();
			cy.get("span:contains(Add Task)").click();
			cy.wait(2000);
			cy.get("a:contains(checkboxes)").eq(0).click();
			cy.get("input[value=1000][type=checkbox]").eq(0).click();
			cy.get("select[name$='::task_type_id']").select("Email");
			cy.get("input[name$='::name']").type("Test Task");
			cy.get(".calendar").click({force: true});
			cy.get(".ui-state-highlight").click();
			
			cy.get("input[id$='::due_ts']").then((date) => {
				var dateSlashed = date.val();
				cy.get("input[value=Create]").click();
				
				cy.get("th:contains('Due Date')").parent("tr").parent("thead").parent("table").find("tbody").find("tr").last().find("td").eq(1).should(($dueDate) => {
					expect($dueDate).to.contain(dateSlashed);
				});
				cy.get("th:contains('Type')").parent("tr").parent("thead").parent("table").find("tbody").find("tr").last().find("td").eq(2).should(($type) => {
					expect($type).to.contain("Email");
				});
				cy.get("th:contains('Description')").parent("tr").parent("thead").parent("table").find("tbody").find("tr").last().find("td").eq(3).should(($description) => {
					expect($description).to.contain("Test Task");
				});
				cy.get("th:contains('Assigned To')").parent("tr").parent("thead").parent("table").find("tbody").find("tr").last().find("td").eq(5).should(($assigned) => {
					expect($assigned).to.contain("Foundant Technologies");
				});
				cy.get("th:contains('Created By')").parent("tr").parent("thead").parent("table").find("tbody").find("tr").last().find("td").eq(6).should(($created) => {
					expect($created).to.contain("Foundant Technologies");
				});
				cy.get("a:contains(done)").last().click();
				cy.get("span:contains(Completed Tasks)").click();
				cy.get("th:contains('Due Date')").parent("tr").parent("thead").parent("table").find("tbody").find("tr").last().find("td").eq(0).should(($dueDate) => {
					expect($dueDate).to.contain(dateSlashed);
				});
				cy.get("th:contains('Type')").parent("tr").parent("thead").parent("table").find("tbody").find("tr").last().find("td").eq(1).should(($type) => {
					expect($type).to.contain("Email");
				});
				cy.get("th:contains('Description')").parent("tr").parent("thead").parent("table").find("tbody").find("tr").last().find("td").eq(2).should(($description) => {
					expect($description).to.contain("Test Task");
				});
				cy.get("th:contains('Assigned To')").parent("tr").parent("thead").parent("table").find("tbody").find("tr").last().find("td").eq(5).should(($assigned) => {
					expect($assigned).to.contain("Foundant Technologies");
				});
				cy.get("th:contains('Created By')").parent("tr").parent("thead").parent("table").find("tbody").find("tr").last().find("td").eq(6).should(($created) => {
					expect($created).to.contain("Foundant Technologies");
				});
				
				cy.get("span:contains(Add Task)").click();
				cy.wait(2000);
				cy.get("a:contains(checkboxes)").eq(0).click();
				cy.get("input[value=1000][type=checkbox]").eq(0).click();
				cy.get("select[name$='::task_type_id']").select("Call");
				cy.get("input[name$='::name']").type("Test Task 2");
				cy.get(".calendar").click({force: true});
				cy.get(".ui-state-highlight").click();
				cy.get("input[name$='::reoccur_num']").type("1");
				cy.get("select[name$='::reoccur_type']").select("day(s)");
				cy.get("input[id$='::due_ts']").then((date) => {
					var dateSlashed = date.val();
					cy.get("input[value=Create]").click();
					
					cy.get("th:contains('Due Date')").parent("tr").parent("thead").parent("table").find("tbody").find("tr").last().find("td").eq(1).should(($dueDate) => {
						expect($dueDate).to.contain(dateSlashed);
					});
					cy.get("th:contains('Type')").parent("tr").parent("thead").parent("table").find("tbody").find("tr").last().find("td").eq(2).should(($type) => {
						expect($type).to.contain("Call");
					});
					cy.get("th:contains('Description')").parent("tr").parent("thead").parent("table").find("tbody").find("tr").last().find("td").eq(3).should(($description) => {
						expect($description).to.contain("Test Task 2");
					});
					cy.get("th:contains('Assigned To')").parent("tr").parent("thead").parent("table").find("tbody").find("tr").last().find("td").eq(5).should(($assigned) => {
						expect($assigned).to.contain("Foundant Technologies");
					});
					cy.get("th:contains('Created By')").parent("tr").parent("thead").parent("table").find("tbody").find("tr").last().find("td").eq(6).should(($created) => {
						expect($created).to.contain("Foundant Technologies");
					});
					cy.get("a:contains(done)").last().click();
					cy.get("span:contains(Completed Tasks)").click();
					cy.get("td:contains('Test Task 2')").should('not.exist');
				});
			});
		});
	});
});