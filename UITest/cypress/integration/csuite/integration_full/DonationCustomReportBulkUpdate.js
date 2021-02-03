describe('Full Test', ()=> {
	context("Custom Donation Custom Report Bulk Update", () => {
		it("Custom Donation Custom Report Bulk Update Test", () => {
			cy.csuite_login(Cypress.env("CS_USER"), Cypress.env("CS_PASSWORD"));
			cy.wait(2000);

			cy.createngagementstrategy("Custom Engagement Strategy");
			cy.wait(2000);
			
			cy.createsteward("1002");
			cy.wait(2000);

			cy.get("a:contains(Home)").click();
			cy.get("a:contains(Reports)").click();
			cy.wait(2000);
			cy.get("a[data-report-object='donation']").click();
			cy.wait(2000);
			cy.get("a:contains('Profile Id')").eq(0).click();
			cy.wait(2000);
			cy.get("button[value=addfilter]").click();
			cy.get("button:contains('Type of Profile')").click();
			cy.get("input[value=org]").click();
			cy.get("input[value='Apply Report Filter']").click();
			
			cy.get("span:contains('Add To Campaign')").click();
			cy.wait(2000);
			cy.get("a:contains('Event 1 :: 2018-05-07')").eq(0).click();
			cy.get("a:contains('Yes')").click();
			cy.get("div:contains('2 Profiles added to event Event 1 :: 2018-05-07')").should("exist");
			
			cy.get("span:contains('Remove From Campaign')").click();
			cy.wait(2000);
			cy.get("a:contains('Event 1 :: 2018-05-07')").eq(0).click();
			cy.get("a:contains('Yes')").click();
			cy.get("div:contains('2 Profiles removed from event Event 1 :: 2018-05-07')").should("exist");

			cy.get("span:contains('Add To Profile Type')").click();
			cy.wait(2000);
			cy.get("a:contains('Community Foundation')").click();
			cy.get("a:contains('Yes')").click();
			cy.get("div:contains('2 Profiles added to profile type Community Foundation')").should("exist");
			
			cy.get("span:contains('Delete From Profile Type')").click();
			cy.wait(2000);
			cy.get("a:contains('Community Foundation')").click();
			cy.get("a:contains('Yes')").click();
			//cy.get("div:contains('2 Profiles added to profile type Community Foundation')").should("exist");

			cy.get("span:contains('Add To Engagement Strategy')").click();
			cy.wait(2000);
			cy.get("a:contains('Custom Engagement Strategy')").click();
			cy.get("a:contains('Yes')").click();
			cy.get("div:contains('2 Profiles added to Custom Engagement Strategy')").should("exist");
			
			cy.get("span:contains('Delete From Engagement Strategy')").click();
			cy.wait(2000);
			cy.get("a:contains('Custom Engagement Strategy')").click();
			cy.get("a:contains('Yes')").click();
			//cy.get("div:contains('2 Profiles removed from Custom Engagement Strategy')").should("exist");

			cy.get("span:contains('Add To Grant Type')").click();
			cy.wait(2000);
			cy.get("a:contains('Grant Type 1')").click();
			cy.get("a:contains('Yes')").click();
			cy.get("div:contains('2 Profiles added to grant type Grant Type 1')").should("exist");
			
			cy.get("span:contains('Delete From Grant Type')").click();
			cy.wait(2000);
			cy.get("a:contains('Grant Type 1')").click();
			cy.get("a:contains('Yes')").click();
			cy.get("div:contains('2 Profiles removed from grant type Grant Type 1')").should("exist");

			cy.get("span:contains('Add Steward')").click();
			cy.wait(2000);
			cy.get("a:contains('Employee 2')").click();
			cy.get("a:contains('Yes')").click();
			cy.get("div:contains('2 Profiles assigned to Employee 2')").should("exist");
			
			cy.get("span:contains('Remove Steward')").click();
			cy.wait(2000);
			cy.get("a:contains('Yes')").click();
			cy.get("div:contains('Stewards were removed from 2 profiles')").should("exist");
			
			cy.deleteSteward("1002");
		});
	});
});