describe('Sweep Test', ()=> {
	context("Create and edit Admin Fee", () => {
		it("Create and edit Admin Fee Test", () => {
			cy.csuite_login(Cypress.env("CS_USER"), Cypress.env("CS_PASSWORD"));
			cy.wait(2000);
			cy.get("a:contains(Admin Fee)").click();
			cy.get("span:contains(Fund Fee Types)").click();
			cy.get("span:contains(Create)").click();
			cy.get("input[name$='::name']").type("Test Admin Fee");
			cy.get("select[name$='::fee_type']").select("percent_range");
			cy.get("select[name$='::apply_fee']").select("monthly");
			cy.get("input[value=Create]").click();
			cy.get("span:contains(Edit)").click();
			cy.wait(2000);
			cy.get("input[name$='::range:new1:min_balance']").type("500");
			cy.get("input[name$='::range:new1:fee_percent']").type("0.5");
			cy.get("input[name$='::range:new2:min_balance']").type("1000");
			cy.get("input[name$='::range:new2:fee_percent']").type("0.25");
			cy.get("input[name$='::funit:1006']").click();
			cy.get("input[name$='::funit:1007']").click();
			cy.get("input[value=Update]").eq(0).click();

			cy.get("th:contains('Name')").parent("tr").find("td").should(($name) => {
				expect($name).to.contain("Test Admin Fee");
			});
			cy.get("th:contains('Fee Type')").parent("tr").find("td").should(($feetype) => {
				expect($feetype).to.contain("percent_range");
			});
			cy.get("th:contains('Apply Fee')").parent("tr").find("td").should(($applyfee) => {
				expect($applyfee).to.contain("monthly");
			});
			cy.get("caption:contains(Fee Percent Ranges)").parent("table").find("tbody").find("tr").eq(0).find("td").eq(0).should(($balance) =>  {
				expect($balance).to.contain('500.00');
			});
			cy.get("caption:contains(Fee Percent Ranges)").parent("table").find("tbody").find("tr").eq(0).find("td").eq(1).should(($percent) =>  {
				expect($percent).to.contain('50.0000%');
			});
			cy.get("caption:contains(Fee Percent Ranges)").parent("table").find("tbody").find("tr").eq(1).find("td").eq(0).should(($balance) =>  {
				expect($balance).to.contain('1,000.00');
			});
			cy.get("caption:contains(Fee Percent Ranges)").parent("table").find("tbody").find("tr").eq(1).find("td").eq(1).should(($percent) =>  {
				expect($percent).to.contain('25.0000%');
			});
			cy.get("caption:contains(Funds)").parent("table").find("tbody").find("tr").eq(0).find("td").eq(0).find("a").should(($fund) =>  {
				expect($fund).to.contain('Deposit Fund 1 :: Fund Group 1');
			});
			cy.get("caption:contains(Funds)").parent("table").find("tbody").find("tr").eq(1).find("td").eq(0).find("a").should(($fund) =>  {
				expect($fund).to.contain('Deposit Fund 2 :: Fund Group 1');
			});

			cy.get("a:contains(Home)").click();
			cy.get("a:contains(Admin Fee)").click();
			cy.get("span:contains(Fee Fund Groups)").click();
			cy.get("span:contains(Create)").click();
			cy.get("input[name$='::name']").type("Test Fee Group");
			cy.get("input[value=Create]").click();
			cy.get("span:contains(Edit)").click();
			cy.get("input[name$='::funit:1006']").click();
			cy.get("input[name$='::funit:1007']").click();
			cy.get("input[value=Update]").eq(0).click();
			
			cy.get("th:contains('Name')").parent("tr").find("td").should(($name) => {
				expect($name).to.contain("Test Fee Group");
			});
			
			cy.get("caption:contains(Funds)").parent("table").find("tbody").find("tr").eq(0).find("td").eq(0).find("a").should(($fund) =>  {
				expect($fund).to.contain("Deposit Fund 1 :: Fund Group 1");
			});
			cy.get("caption:contains(Funds)").parent("table").find("tbody").find("tr").eq(0).find("td").eq(1).should(($type) =>  {
				expect($type).to.contain("Test Admin Fee");
			});

			cy.get("caption:contains(Funds)").parent("table").find("tbody").find("tr").eq(1).find("td").eq(0).find("a").should(($fund) =>  {
				expect($fund).to.contain("Deposit Fund 2 :: Fund Group 1");
			});
			cy.get("caption:contains(Funds)").parent("table").find("tbody").find("tr").eq(1).find("td").eq(1).should(($type) =>  {
				expect($type).to.contain("Test Admin Fee");
			});


			cy.get("a:contains(Home)").click();
			var mInternalDonationProfile = "School Vendor Profile First Name";
			var mInternalDonationFund = "Deposit Fund 2";
			var mInternalDonationDescription = "1 Ýeû#ÒS WR¥Ä2bJ";
			var mInternalDonationAmount = "600.00";
			cy.wait(2000);		
			cy.createDonation(mInternalDonationProfile,mInternalDonationDescription,mInternalDonationAmount,mInternalDonationFund,false);

			var date = new Date();
			var month = date.getMonth();
			var day = "";
			switch(month)
			{
				case 1:
					if(date.getFullYear() % 4 == 0 && date.getFullYear() % 400 == 0)
					{
						day = "29";
					}
					else
					{
						day = "28";
					}

				break;ak;
				case 3:
				case 5:
				case 8:
				case 10:
					day = "30";
				break;
				case 0:
				case 2:
				case 4:
				case 6:
				case 7:
				case 9:
				case 11:
					day = "31";
				break;
			}

			var strMonth = (month + 1).toString();
			if(strMonth.length == 1)
			{
				strMonth = "0" + strMonth;
			}

			var adminFeeDate = date.getFullYear() + "-" + strMonth + "-" + day;

			cy.get("a:contains(Home)").click();
			cy.get("a:contains(Admin Fee)").click();
			cy.get("span:contains(Create)").click();
			cy.wait(2000);
			cy.get("input[id$='::date']").type(adminFeeDate);
			cy.get("input[name$='::description']").type("Admin Fee Test Description");
			cy.get("input[value=Next]").click();
			cy.wait(15000);
			cy.reload();

			cy.get("td:contains(Admin Fee Test Description)").eq(1).parent("tr").find("td").eq(0).find("a").click();

			cy.get("caption:contains(Details)").parent("table").find("tbody").find("tr").eq(2).find("td").eq(0).find("a").should(($fund) =>  {
				expect($fund).to.contain('Deposit Fund 2');
			});
			cy.get("caption:contains(Details)").parent("table").find("tbody").find("tr").eq(2).find("td").eq(1).find("a").should(($account) =>  {
				expect($account).to.contain('12345678-Bank :: Another Checking Account (A)');
			});
			cy.get("caption:contains(Details)").parent("table").find("tbody").find("tr").eq(2).find("td").eq(3).should(($description) =>  {
				expect($description).to.contain('Monthly Test Admin Fee (50.00% of 600.00 [Test Fee Group:100.00%:600.00])');
			});
			cy.get("caption:contains(Details)").parent("table").find("tbody").find("tr").eq(2).find("td").eq(4).should(($description) =>  {
				expect($description).to.contain('25.00');
			});
			
			cy.get("a:contains(Delete)").click();
			cy.get("a:contains(Yes)").click();
			
			cy.get("a:contains(Home)").click();
			cy.get("a:contains(Admin Fee)").click();
			cy.get("span:contains(Fee Fund Groups)").click();
			cy.get("td:contains(Test Fee Group)").eq(1).parent("tr").find("td").eq(0).find("a").click();
			
			cy.get("span:contains(Edit)").click();
			cy.get("input[name$='::funit:1006']").click();
			cy.get("input[name$='::funit:1007']").click();
			cy.get("input[value=Update]").eq(0).click();
			
			cy.get("a:contains(Delete)").click();
			
			cy.visit("/erp/funit/display?funit_id=1006");
			cy.get("a[href*='/erp/funit/delete/feetype']").click();
			
			cy.visit("/erp/funit/display?funit_id=1007");
			cy.get("a[href*='/erp/funit/delete/feetype']").click();
			
			cy.wait(2000);
			cy.transferFunds(1007, "Some Fund", 600);
		});
	});
});
