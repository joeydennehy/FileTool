describe('Full Test', ()=> {
	context("campaign", () => {
		it("campaign Test", () => {
			cy.csuite_login(Cypress.env("CS_USER"), Cypress.env("CS_PASSWORD"));
			cy.wait(2000);
			cy.get("a:contains(Campaigns)").click();
			cy.get("span:contains(Add Campaign)").click();
			cy.get("select[name$='::event_id']").select("Event 1");
			cy.get("input[id$='::event_date']").type((new Date().getFullYear() + 1) + "-01-01");
			cy.get("input[name$='::description']").type("Test Campaign");
			
			cy.get("input[id$='event_date']").then((date) => {
				var mCampaignDateSlashed = date.val().substring(5,7) + "/" + date.val().substring(8,10) + "/" + date.val().substring(0,4);
				cy.get("input[value='Create']").click();
				cy.wait(2000);
				cy.location().then((loc) => {
					cy.log(loc.href);
				var eventIdIndex = loc.href.indexOf('event_date_id=');
				var eventId = loc.href.substring(eventIdIndex + 14);
				cy.get("span:contains(Edit)").click();
				cy.wait(2000);
				cy.get("input[name$='::online_ticket_sales']").click();
				cy.get("input[data-search-value='funit_id']").type("Another Fund");
				cy.get("div:contains(Another Fund)").click();
				cy.get("input[value='Save']").click();
				cy.get("th:contains(Campaign Date)").parent("tr").find("td").should(($created) =>  {
					expect($created).to.contain(mCampaignDateSlashed);
				});
				cy.get("th:contains(Group)").parent("tr").find("td").find("a").should(($group) =>  {
					expect($group).to.contain("Event 1");
				});
				cy.get("th:contains(Description)").parent("tr").find("td").should(($description) =>  {
					expect($description).to.contain("Test Campaign");
				});
				cy.get("span:contains('Add Ticket')").click();
				cy.get("input[name$='::name']").type("Test Ticket");
				cy.get("input[name$='::ticket_units']").type("1");
				cy.get("input[name$='::ticket_price']").type("12");
				cy.get("input[name$='::ticket_value']").type("5");
				cy.get("input[name$='::available_tickets']").type("10");
				cy.get("input[name$='::private']").click();
				cy.get("select[name$='::revenue_account_id']").select("12345674-Other Income :: Internal Loans Principal Due to Investors Liability (R)");
				cy.get("input[name$='::sort_order']").type("5");
				cy.get("input[name$='::sponsorship_type']").click();
				cy.get("input[name$='::additional_donation']").click();
				cy.get("input[value='Create']").click();

				cy.get("th:contains(Name)").parent("tr").find("td").should(($name) =>  {
					expect($name).to.contain('Test Ticket');
				});
				cy.get("th:contains(Campaign Name)").parent("tr").find("td").find("a").should(($campaign) =>  {
					expect($campaign).to.contain('Event 1 :: ' + date.val() + ' :: Test Campaign');
				});
				cy.get("th:contains(Units)").parent("tr").find("td").should(($units) =>  {
					expect($units).to.contain('1');
				});
				cy.get("th:contains(Price)").parent("tr").find("td").should(($price) =>  {
					expect($price).to.contain('12.00');
				});
				cy.get("th:contains(Value)").parent("tr").find("td").should(($value) =>  {
					expect($value).to.contain('5.00');
				});
				cy.get("th:contains(Total)").parent("tr").find("td").should(($total) =>  {
					expect($total).to.contain('10');
				});
				cy.get("th:contains(Avail)").parent("tr").find("td").should(($avail) =>  {
					expect($avail).to.contain('10');
				});
				cy.get("th:contains(Private)").parent("tr").find("td").should(($private) =>  {
					expect($private).to.contain('Yes');
				});
				cy.get("th:contains(Revenue Account)").parent("tr").find("td").find("a").should(($revenue) =>  {
					expect($revenue).to.contain('Internal Loans Principal Due to Investors Liability');
				});
				cy.get("th:contains(Sort Order)").parent("tr").find("td").should(($sort) =>  {
					expect($sort).to.contain('5');
				});
				cy.get("th:contains(Sponsorship Type)").parent("tr").find("td").should(($sponsorship) =>  {
					expect($sponsorship).to.contain('Yes');
				});
				cy.get("th:contains(Additional Donation)").parent("tr").find("td").should(($donation) =>  {
					expect($donation).to.contain('Yes');
				});
				cy.get("a:contains(Event 1 :: " + date.val() + " :: Test Campaign)").click();

				cy.get("th:contains(Profile)").parent("tr").find("td").find("input").type("Individual1 Last Name, Individual1 First Name");
				cy.get("div:contains('Individual1 Last Name, Individual1 First Name')").click();

				cy.get("th:contains(Profile)").parent("tr").find("td").find("input").type("HouseHold1 Member1 Last Name, HouseHold1 Member1 First Name");
				cy.get("div:contains('HouseHold1 Member1 Last Name, HouseHold1 Member1 First Name')").click();
			
				cy.get("th:contains(Profile)").parent("tr").find("td").find("input").type("Grantee Organization1");
				cy.get("div:contains('Grantee Organization1')").click();

				cy.get("th:contains('Primary Profile (3)')").parent("tr").parent("thead").parent("table").find("tbody").find("tr").eq(0).find("td").eq(0).find("a").should(($invitee) =>  {
					expect($invitee).to.contain('Grantee Organization1');
				});
				cy.get("th:contains('Primary Profile (3)')").parent("tr").parent("thead").parent("table").find("tbody").find("tr").eq(1).find("td").eq(0).find("a").should(($invitee) =>  {
					expect($invitee).to.contain('HouseHold1 Member1 Last Name, HouseHold1 Member1 First Name');
				});
				cy.get("th:contains('Primary Profile (3)')").parent("tr").parent("thead").parent("table").find("tbody").find("tr").eq(2).find("td").eq(0).find("a").should(($invitee) =>  {
					expect($invitee).to.contain('Individual1 Last Name, Individual1 First Name');
				});

				cy.get("span:contains(Add Request)").click();
				cy.get("input[name$='::name']").type("Test Campaign Request");
				cy.get("input[value=Create]").click();
				cy.get("a:contains('Event 1 :: " + date.val() + " :: Test Campaign')").click();
				cy.get("caption:contains(Request)").parent("table").find("tbody").find("tr").find("td").eq(1).should(($request) =>  {
					expect($request).to.contain('Test Campaign Request');
				});

				cy.get("span:contains('Add Ticket')").click();
				cy.get("input[name$='::name']").type("Test 0 dollar Ticket");
				cy.get("input[name$='::ticket_units']").type("1");
				cy.get("input[name$='::ticket_price']").type("0");
				cy.get("input[name$='::ticket_value']").type("0");
				cy.get("input[name$='::available_tickets']").type("10");
				cy.get("select[name$='::revenue_account_id']").select("12345674-Other Income :: Internal Loans Principal Due to Investors Liability (R)");
				cy.get("input[name$='::sort_order']").type("5");
				cy.get("input[name$='::sponsorship_type']").click();
				cy.get("input[name$='::additional_donation']").click();
				
				cy.get("input[value='Create']").click();

				cy.visit("/erp/donate/list/ticket");
				cy.get("a[href='/erp/donate/list/event?event_date_id=" + eventId + "']").click();
				cy.get("a:contains(Test 0 dollar Ticket)").click();
				cy.get("a:contains(Test 0 dollar Ticket)").click();
				cy.get("input[name='tickets']").type("1");
				cy.get("input[value='Add To Cart']").click();
				cy.get("a:contains(Checkout)").click();
				cy.get("input[name$='::first_name']").type("Campaign");
				cy.get("input[name$='::last_name']").type("One");
				cy.get("input[name$='::address']").type("1111 Somewhere");
				cy.get("input[name$='::city']").type("Bozeman");
				cy.get("input[name$='::zipcode']").type("59718");
				cy.get("input[name$='::email']").type("campaing@test.invalid");
				cy.get("input[name$='::phone']").type("555-555-5555");
				cy.get("input[value='Review']").click();
				cy.get("input[value='Submit Registration']").click();

				cy.visit("/erp/event/display/eventdate?event_id=1000&event_date_id=" + eventId);
				
				cy.get("caption:contains(Tickets)").parent("table").find("tbody").find("tr").eq(0).find("td").eq(1).should(($name) =>  {
					expect($name).to.contain('Test 0 dollar Ticket');
				});
				cy.get("caption:contains(Tickets)").parent("table").find("tbody").find("tr").eq(0).find("td").eq(5).should(($total) =>  {
					expect($total).to.contain('10');
				});
				cy.get("caption:contains(Tickets)").parent("table").find("tbody").find("tr").eq(0).find("td").eq(6).should(($avail) =>  {
					expect($avail).to.contain('9');
				});
				cy.get("caption:contains(Tickets)").parent("table").find("tbody").find("tr").eq(0).find("td").eq(7).should(($sold) =>  {
					expect($sold).to.contain('1');
				});
				cy.get("caption:contains(Tickets)").parent("table").find("tbody").find("tr").eq(0).find("td").eq(8).should(($soldunit) =>  {
					expect($soldunit).to.contain('1');
				});

				cy.get("span:contains(Sell Ticket)").click();
				cy.get("input[id=search]").type("Individual1 Last Name, Individual1 First Name");
				cy.get("div:contains(Individual1 Last Name, Individual1 First Name)").click();
				cy.get("a:contains(Test Ticket)").click();
				cy.get("input[name='num']").type("1");
				cy.get("input[value=1001]").click();
				cy.get("input[value=Process]").click();

				cy.visit("/erp/event/display/eventdate?event_date_id=" + eventId);

				cy.get("caption:contains(Tickets)").parent("table").find("tbody").find("tr").eq(1).find("td").eq(1).should(($name) =>  {
					expect($name).to.contain('Test Ticket');
				});
				cy.get("caption:contains(Tickets)").parent("table").find("tbody").find("tr").eq(1).find("td").eq(5).should(($total) =>  {
					expect($total).to.contain('10');
				});
				cy.get("caption:contains(Tickets)").parent("table").find("tbody").find("tr").eq(1).find("td").eq(6).should(($avail) =>  {
					expect($avail).to.contain('9');
				});
				cy.get("caption:contains(Tickets)").parent("table").find("tbody").find("tr").eq(1).find("td").eq(7).should(($sold) =>  {
					expect($sold).to.contain('1');
				});
				cy.get("caption:contains(Tickets)").parent("table").find("tbody").find("tr").eq(1).find("td").eq(8).should(($soldunit) =>  {
					expect($soldunit).to.contain('1');
				});

				cy.get("a:contains('add guest')").eq(0).click();
				cy.get("input[id=search]").type("No Name Individual");
				cy.get("div:contains(No Name Individual)").click();
        
				cy.visit("/erp/event/display/eventdate?event_date_id=" + eventId);

				cy.get("caption:contains(Invitees)").parent("table").find("tbody").find("tr").eq(3).find("td").eq(1).find("a").should(($invitee) =>  {
					expect($invitee).to.contain('No Name Individual');
				});

				cy.get("a:contains('add guest')").eq(0).click();
				
				cy.get("input[name$='::first_name']").type("Campaign");
				cy.get("input[name$='::last_name']").type("Invitee");
				cy.get("input[value=Save]").click();
        
				cy.visit("/erp/event/display/eventdate?event_date_id=" + eventId);

				cy.get("caption:contains(Invitees)").parent("table").find("tbody").find("tr").eq(5).find("td").eq(1).find("a").should(($invitee) =>  {
					expect($invitee).to.contain('Invitee, Campaign');
				});
			});
			});
		});
	});
});
