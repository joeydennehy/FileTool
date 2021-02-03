describe('Sweep Test', ()=> {
	context("Create and Edit Tribute", () => {
		it("Create and Edit Tribute Test", () => {
			cy.csuite_login(Cypress.env("CS_USER"), Cypress.env("CS_PASSWORD"));
			cy.wait(2000);
			
			cy.get("a:contains(Tributes)").click();
			cy.get("span:contains(Create)").click();
			cy.get("input[name$='::name']").type("Test Tribute");
			cy.get("select[name$='::memorial_type']").select("memory");
			cy.get("input[value=Create]").click();
			cy.get("span:contains(Display)").click();
			cy.get("span:contains(Add Notify)").click();
			cy.get("input[id=search]").type("Donor Last Name, Donor First Name");
			cy.get("div:contains('Donor Last Name, Donor First Name')").click();
			cy.get("select[name$=':notify_method']").select("email");
			cy.get("input[name$=':frequency_interval']").type("1");
			cy.get("input[value=Save]").click();
			cy.get("th:contains(Name)").parent("tr").find("td").should(($name) =>  {
				expect($name).to.contain("Test Tribute");
			});
			cy.get("th:contains(Type)").parent("tr").find("td").should(($type) =>  {
				expect($type).to.contain("memory");
			});

			cy.get("caption:contains(Notify)").parent("table").find("tbody").find("tr").find("td").eq(1).should(($name) =>  {
				expect($name).to.contain("Donor Last Name, Donor First Name");
			});
			cy.get("caption:contains(Notify)").parent("table").find("tbody").find("tr").find("td").eq(2).should(($method) =>  {
				expect($method).to.contain("email");
			});
			cy.get("caption:contains(Notify)").parent("table").find("tbody").find("tr").find("td").eq(3).should(($frequency) =>  {
				expect($frequency).to.contain("00:00:01");
			});
			var mInternalDonationProfile = "School Vendor Profile First Name";
			var mInternalDonationFund = "Another Fund";
			var mInternalDonationDescription = "1 Ýeû#ÒS WR¥Ä2bJ";
			var mInternalDonationAmount = "2,000.00";
			cy.wait(2000);
			cy.createDonation(mInternalDonationProfile,mInternalDonationDescription,mInternalDonationAmount,mInternalDonationFund, true);
			cy.get("a:contains(Home)").click(); 		
			cy.get("a:contains(Tributes)").click();
			cy.get("span:contains(List)").click();
			cy.get("a:contains(1001)").click();
			cy.get("caption:contains(Donations)").parent("table").find("tbody").find("tr").find("td").eq(2).find("a").should(($name) =>  {
				expect($name).to.contain("School Vendor Profile Last Name, School Vendor Profile First Name");
			});
			cy.get("caption:contains(Donations)").parent("table").find("tbody").find("tr").find("td").eq(3).should(($fund) =>  {
				expect($fund).to.contain("Another Fund :: Fund Group 1");
			});
			cy.get("caption:contains(Donations)").parent("table").find("tbody").find("tr").find("td").eq(4).should(($method) =>  {
				expect($method).to.contain("Check");
			});
			cy.get("caption:contains(Donations)").parent("table").find("tbody").find("tr").find("td").eq(5).should(($amount) =>  {
				expect($amount).to.contain("2,000.00");
			});
		});
	});
});
