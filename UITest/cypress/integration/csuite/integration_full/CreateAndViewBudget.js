describe('Full Test', ()=> {
	context("Create and View Budget", () => {
		it("Create and view Budget Test", () => {
			cy.csuite_login(Cypress.env("CS_USER"), Cypress.env("CS_PASSWORD"));
			cy.wait(2000);
			cy.createFund("Budget Fund","Fund Group 1","default_checking-Bank :: Checking (A)", true);
			cy.get("a:contains(Home)").click();
			cy.get("a:contains(Budget)").click();
			cy.get("span:contains(Create)").click()
			var year = new Date().getFullYear() + 1;
			cy.get("input[name$='::year']").type(year);
			cy.get("input[value=Create]").click();
			cy.get("a:contains('Budget Fund')").eq(0).click();
			cy.get("caption:contains('Budget Fund Budget')").parent("table").find("tbody").find("tr").eq(2).find("td").eq(4).find("input").type(10000);
			cy.get("input[value=Update]").eq(0).click();
			cy.get("a:contains('invoice_revenue')").click({force: true});
			cy.get("caption:contains('Invoice Revenue Budget')").parent("table").find("tbody").find("tr").eq(3).find("td").eq(4).find("input").should('have.value', '833.33');
			cy.get("caption:contains('Invoice Revenue Budget')").parent("table").find("tbody").find("tr").eq(4).find("td").eq(4).find("input").should('have.value', '833.33');
			cy.get("caption:contains('Invoice Revenue Budget')").parent("table").find("tbody").find("tr").eq(5).find("td").eq(4).find("input").should('have.value', '833.33');
			cy.get("caption:contains('Invoice Revenue Budget')").parent("table").find("tbody").find("tr").eq(6).find("td").eq(4).find("input").should('have.value', '833.33');
			cy.get("caption:contains('Invoice Revenue Budget')").parent("table").find("tbody").find("tr").eq(7).find("td").eq(4).find("input").should('have.value', '833.33');
			cy.get("caption:contains('Invoice Revenue Budget')").parent("table").find("tbody").find("tr").eq(8).find("td").eq(4).find("input").should('have.value', '833.33');
			cy.get("caption:contains('Invoice Revenue Budget')").parent("table").find("tbody").find("tr").eq(9).find("td").eq(4).find("input").should('have.value', '833.33');
			cy.get("caption:contains('Invoice Revenue Budget')").parent("table").find("tbody").find("tr").eq(10).find("td").eq(4).find("input").should('have.value', '833.33');
			cy.get("caption:contains('Invoice Revenue Budget')").parent("table").find("tbody").find("tr").eq(11).find("td").eq(4).find("input").should('have.value', '833.33');
			cy.get("caption:contains('Invoice Revenue Budget')").parent("table").find("tbody").find("tr").eq(12).find("td").eq(4).find("input").should('have.value', '833.33');
			cy.get("caption:contains('Invoice Revenue Budget')").parent("table").find("tbody").find("tr").eq(13).find("td").eq(4).find("input").should('have.value', '833.33');
			cy.get("caption:contains('Invoice Revenue Budget')").parent("table").find("tbody").find("tr").eq(14).find("td").eq(4).find("input").should('have.value', '833.33');
			cy.get("a:contains(Home)").click();
			cy.get("a:contains(Financials)").eq(0).click();
			cy.get("span:contains('Income Statement')").click();
			var date = "01/01/" + year;
			cy.get("input[id$='::from']").type(year + "-01-01");
			cy.get("input[id$='::to']").type(year + "-12-31");
			cy.get("input[value='Show Date']").click();
			cy.get("select[id='setcol']").eq(0).select('budget');
			cy.get("caption:contains('Statement of Activities')").parent("table").find("tbody").find("tr").eq(2).find("td").eq(5).should(($amount) =>  {
					expect($amount).to.contain("9,999.96");
				});
			cy.get("caption:contains('Statement of Activities')").parent("table").find("tbody").find("tr").eq(2).find("td").eq(6).should(($amount) =>  {
					expect($amount).to.contain("(9,999.96)");
				});
			cy.get("caption:contains('Statement of Activities')").parent("table").find("tbody").find("tr").eq(2).find("td").eq(7).should(($amount) =>  {
					expect($amount).to.contain("-0.0%");
				});
			cy.get("a:contains(Home)").click();
			cy.get("a:contains(Budget)").click();
			cy.get("a:contains(" + date + ")").click();
			cy.get("span:contains(Delete)").click();
			cy.get("a:contains(Yes)").click();
		});
	});
});
