Feature: JourneyPlanner

Background:
    Given user is on "https://tfl.gov.uk/"

Scenario: Valid Journey
    When user searches from "Croydon (London), East Croydon Station"
    And user searches to "Upminster Bridge Underground Station"
    And user click on Plan my journey
    Then user should see "Croydon (London), East Croydon Station" on Journey results page

Scenario: Invalid Journey
    When user searches from postcode "RM15 5FW"
    And user searches to postcode "N1 8AF"
    And user click on Plan my journey
    Then user should see an error "Sorry, we can't find a journey matching your criteria"

Scenario: No Locations 
    When user click on Plan my journey
    Then user should see an error "The From field is required"
    And user should see an error "The To field is required"

Scenario: Edit Journey
    When user searches from "Croydon (London), East Croydon Station"
    And user searches to "Upminster Bridge Underground Station"
    And user click on Plan my journey
    And user click on Edit Journey
    And changes the from field to "East Croydon"
    And user clicks on Update Journey
    Then user should see "Croydon (London), East Croydon Station" on Journey results page
    
    
Scenario: Recents tab
    When user click on Recents tab
    Then user should able to see recent search stations "Hammersmith to Victoria"

    
