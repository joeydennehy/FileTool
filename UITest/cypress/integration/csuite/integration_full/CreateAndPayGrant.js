describe('Sweep Test', ()=>{
	context ("Create And Pay Grant",() => {		
		it("Created Grant and Pay Grant Test", () => {
			cy.csuite_login(Cypress.env("CS_USER"), Cypress.env("CS_PASSWORD"));
			
			var mExternalGrantGrantee = "School Vendor Profile First Name";
			
			cy.wait(2000);
			cy.get("a:contains('Home')").click();
			cy.get("a:contains('Grants')").eq(0).click();
			cy.get("span:contains('Create')").eq(0).click();
			cy.get("input[id='search']").type(mExternalGrantGrantee);
			cy.get("li:contains(" + mExternalGrantGrantee + ")").click();
			cy.get(".calendar").click({force: true});
			cy.get(".ui-state-highlight").click();
			cy.get("input[name$='grant_date']").then((date) => {
				var mExternalGrantDateSlashed = date.val();
				
				var mExternalGrantDescription = "1 Ýeû#ÒS WR¥Ä2bJ";
				cy.get("input[name$='description']").type(mExternalGrantDescription);
				var mExternalGrantAmount = "2,000.00";
				cy.get("input[name$='amount']").type(mExternalGrantAmount);
				var mExternalGrantSummary = "îÐcsL2õ5èÃá&aúne";
				cy.get("textarea[name$='summary']").type(mExternalGrantSummary);
				var mExternalGrantFund = "Another Fund";
				cy.get("input[data-widget]").type(mExternalGrantFund);				
				cy.get("li:contains(" + mExternalGrantFund + ")").click();
				cy.get("input[type='submit']").click();
				
				cy.get("th:contains('ID')").parent("tr").find("td").find("a").then((Id) => {
					var mExternalGrantID = Id.html();
					cy.get("th:contains(Created)").parent("tr").find("td").should(($created) =>  {
						expect($created).to.contain(mExternalGrantDateSlashed);
					});
					cy.get("th:contains(Created)").parent("tr").find("td").should(($created) =>  {
						expect($created).to.contain(mExternalGrantDateSlashed);
					});
					cy.get("th:contains(Grant Date)").parent("tr").find("td").should(($grantdate) =>  {
						expect($grantdate).to.contain(mExternalGrantDateSlashed);
					});
					cy.get("th:contains(Status)").parent("tr").find("td").should(($status) =>  {
						expect($status).to.contain("new");
					});
					cy.get("th:contains(Grantee)").parent("tr").find("td").should(($grantee) =>  {
						expect($grantee).to.contain(mExternalGrantGrantee);
					});
					cy.get("input[id=omnisearch]").type(mExternalGrantID);
					cy.get("div:contains(Grant " + mExternalGrantID + ")").click();
					cy.get("th:contains(ID)").parent("tr").find("td").should(($id) =>  {
						expect($id).to.contain(mExternalGrantID);
					});
					cy.get("a:contains(manually checked)").click();
					cy.get("span:contains(Add Funding)").click();
					cy.get("input[id*='::amount']").type(2000);
					cy.get("input[value='Save']").click();
					cy.get("span:contains(Post & Get Approval)").click();
					
					cy.get("body").then(($body) => 
					{
						if($body.find("div[class='warning']").length > 0)
						{
							cy.get("a:contains(OK, override balance check anyway)").click();
						}
					});
					cy.get("span:contains(I Approve)").click();
					cy.get("span:contains('Approval')").parent("div").parent("caption").parent("table").find("tbody").find("tr").eq(0).find("td").eq(1).should(($approve) => {
						expect($approve).to.contain("Yes");
					});
					cy.get("th:contains(Status)").parent("tr").find("td").should(($voucher) =>  {
						expect($voucher).to.contain("voucher");
					});
					cy.get("input[id=omnisearch]").type(mExternalGrantID);
					cy.get("div:contains(Grant " + mExternalGrantID + ")").click();
					cy.get("a:contains(approve payment)").click();
					cy.get("span:contains(Grant Payment Schedule)").parent("div").parent("caption").parent("table").find("tbody").find("tr").find("td").eq(3).find("a:contains(create)").click();
					cy.get("span:contains(Grant Payment Schedule)").parent("div").parent("caption").parent("table").find("tbody").find("tr").find("td").eq(4).find("a:contains(pay)").click();
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
					});
				});
			});
		});	
	});
});