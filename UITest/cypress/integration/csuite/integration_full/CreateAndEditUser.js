describe('Sweep Test', ()=> {
	context("Create and Edit User", () => {
		it("Create and Edit User Test", () => {
			cy.csuite_login(Cypress.env("CS_USER"), Cypress.env("CS_PASSWORD"));
			cy.wait(2000);
			cy.get("a:contains(Users)").click();
			cy.get("span:contains(Create)").click();
			cy.get("input[name$='::name']").type("Test User");
			cy.get("input[name$='::login']").type("TestUser@test.invalid");
			cy.get("input[name$='::passwd']").type("password");
			cy.get("input[name$='::email']").type("TestUser@test.invalid");
			cy.get("input[value=Create]").click();
			cy.get("th:contains(Name)").parent("tr").find("td").should(($name) => {
				expect($name).to.contain("Test User");
			});
			cy.get("th:contains(Login)").parent("tr").find("td").should(($login) => {
				expect($login).to.contain("testuser@test.invalid");
			});
			cy.get("th:contains(Email)").parent("tr").find("td").should(($email) => {
				expect($email).to.contain("testuser@test.invalid");
			});
			cy.get("span:contains(Edit)").click();
			cy.get("input[name$='::name']").clear();
			cy.get("input[name$='::name']").type("Test New User");
			cy.get("th:contains(Group Name)").parent("tr").parent("thead").parent("table").find("tbody").find("tr").eq(1).find("td").find("input").click();
			cy.get("input[value=Save]").click();
			cy.get("th:contains(Name)").parent("tr").find("td").should(($name) => {
				expect($name).to.contain("Test New User");
			});
			cy.get("a:contains(Admin)").should("exist");
			cy.get("span:contains(Set Password)").click();
			cy.get("input[name$='::pw']").type("newpassword");
			cy.get("input[value=Save]").click();
			cy.get("span:contains(Delete)").click();
			cy.get("a:contains(Yes)").click();
			cy.get("a:contains(Home)").click();
			cy.get("a:contains(Users)").click();
			cy.get("td:contains(Test New User)").should('not.exist');
		});
	});
});
