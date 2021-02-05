describe('Sweep Test', ()=> {
	context("Create and Pay Scholarship", () => {
		it("Create and Pay Scholarship Test", () => {
			cy.intercept("POST", "/erp/student/list/search").as("loadSearchList");
			cy.csuite_login(Cypress.env("CS_USER"), Cypress.env("CS_PASSWORD"));
			cy.get("a:contains('Students')").click();
			cy.get("th:contains('Student')").parent('tr').find('td').find('input').type('Scholarship Student{ENTER}');
			cy.wait("@loadSearchList");
			cy.get("li:contains(Scholarship Student)").click();
			cy.get("a:contains('Add Scholarship')").click();
			cy.get("a:contains('Coredata Scholarship')").eq(0).click();
			cy.get("input[name$='::amount']").type('1000');
			cy.get("input[id$='::scholarship_date']").type('2020-06-01');
			cy.get("input[type='submit']").click();

			cy.get("th:contains(Award Date)").parent("tr").find("td").should(($awarddate) =>  {
				expect($awarddate).to.contain('2020-06-01');
			});
			cy.get("th:contains(Status)").parent("tr").find("td").should(($status) =>  {
				expect($status).to.contain("new");
			});
			cy.get("th:contains(Student)").parent("tr").find("td").find("a").should(($student) =>  {
				expect($student).to.contain('Student, Scholarship');
			});
			cy.get("th:contains(Scholarship)").parent("tr").find("td").find("a").should(($scholarship) =>  {
				expect($scholarship).to.contain('Coredata Scholarship');
			});
			cy.get("th:contains(Amount)").parent("tr").find("td").should(($amount) =>  {
				expect($amount).to.contain('1,000');
			});

			cy.get("span:contains('Add Payment Date')").click();
			cy.get("input[id$='::payment_date']").type('2020-06-01');
			cy.get("input[name$='::amount']").type('1000');
			cy.get("input[value='Save']").click();
			cy.get("th:contains(Payment Date)").parent("tr").parent("thead").parent("table").find("tbody").find("tr").find("td").should(($paymentDate) =>  {
				expect($paymentDate).to.contain('2020-06-01');
			});
			cy.get("span:contains('Post')").click();
			cy.get("a:contains('OK, override balance check anyway')").click();
			cy.get("th:contains(Status)").parent("tr").find("td").should(($status) =>  {
				expect($status).to.contain("open");
			});
			cy.get(".nextaction").click();
			cy.get("a:contains('set')").click();
			cy.get("input[id='search']").type("School Vendor Profile First Name");
			cy.get("li:contains(School Vendor Profile First Name)").click();
			cy.get("th:contains(Approved)").parent("tr").parent("thead").parent("table").find("tbody").find("tr").find("td").should(($approved) =>  {
				expect($approved).to.contain('Yes');
			});
			cy.get("th:contains(School/Grantee)").parent("tr").parent("thead").parent("table").find("tbody").find("tr").find("td").should(($grantee) =>  {
				expect($grantee).to.contain('School Vendor Profile First Name');
			});
			cy.get("a:contains('pay')").click();
			cy.get("th:contains('ID')").parent("tr").find("td").find("a").then((Id) => {
				var mExternalGrantID = Id.html();

				cy.get("th:contains(Grant Date)").parent("tr").find("td").should(($grantdate) =>  {
					expect($grantdate).to.contain('06/01/2020');
				});
				cy.get("th:contains(Status)").parent("tr").find("td").should(($status) =>  {
					expect($status).to.contain("new");
				});
				cy.get("th:contains(Grantee)").parent("tr").find("td").should(($grantee) =>  {
					expect($grantee).to.contain('School Vendor Profile First Name School Vendor Profile Last Name');
				});
				cy.get("a:contains('manually checked')").click();
				cy.get("a:contains('Post & Get Approval')").click();
				cy.get("a:contains('I Approve')").eq(0).click();
				cy.get("span:contains('Approval')").parent("div").parent("caption").parent("table").find("tbody").find("tr").eq(0).find("td").eq(1).should(($approve) => {
					expect($approve).to.contain("Yes");
				});
				cy.get("th:contains(Status)").parent("tr").find("td").should(($voucher) =>  {
					expect($voucher).to.contain("voucher");
				});
				cy.get(".nextaction").click();
				cy.get(".nextaction").click();
				cy.get(".nextaction").click();
				cy.get("option:contains(Checking)").eq(0).then(($option) => {
					cy.get("select").select($option.val());
					cy.get("th:contains(Payment Date)").parent("tr").find("td").find("button").click();
					cy.get(".ui-state-highlight").click();
					cy.get("a:contains(" + mExternalGrantID + ")").parent("td").parent("tr").find("td").eq(12).find("input").click();
					cy.get("input[type='submit']").click();
					cy.get("input[type='submit']").click();
					cy.wait(2000);
					cy.get("input[id=omnisearch]").type(mExternalGrantID);
					cy.get("li:contains(Grant " + mExternalGrantID + ")").click();
					cy.get("th:contains(Status)").parent("tr").find("td").should(($status) =>  {
						expect($status).to.contain("paid");
					});
					cy.get("a:contains('Complete')").click();
					cy.get("th:contains(Status)").parent("tr").find("td").should(($status) =>  {
						expect($status).to.contain("complete");
					});
				});
			});
		});
	});
});
