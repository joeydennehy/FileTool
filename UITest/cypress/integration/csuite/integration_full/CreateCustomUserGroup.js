describe('Sweep Test', ()=> {
	context("Create Custom User Group", () => {
		it("Create Custom User Group Test", () => {
			cy.csuite_login(Cypress.env("CS_USER"), Cypress.env("CS_PASSWORD"));
			cy.wait(2000);
			cy.get("a:contains(Groups)").click();
			cy.get("span:contains(Create)").click();
			cy.get("input[name$='::name']").type("New User Group");
			cy.get("input[value=Create]").click();
			
			cy.get("th:contains('ID')").parent("tr").find("td").then((Id) => {
				var mUserGroupID = Id.html();
				cy.get("span:contains(Copy Permission)").click();
				cy.get("a:contains(Admin)").click();
				cy.get("span:contains(Permission)").click();
				cy.get("a:contains(New User Group)").parent("td").parent("tr").find("td").eq(3).find("input").should(($permission) => {
					expect($permission).to.be.checked;
				});
				
				cy.get("a:contains(Home)").click();
				cy.get("a:contains(Groups)").click();
				cy.get("a:contains(" + mUserGroupID + ")").click();
				cy.get("span:contains(Group Permission)").click();
				cy.get("a:contains(Check)").parent("td").parent("tr").find("td").eq(2).find("input").check();
				cy.get("input[value=Save]").click();
				cy.get("span:contains(Delete)").click();
				cy.get("a:contains(Yes)").click();
				cy.get("td:contains(New User Group)").should('not.exist');
			});
			
		});
	});
});
