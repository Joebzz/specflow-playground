Feature: Google Search

Scenario: Can find search results
  Given I am on the google page
  When I search for "TestingBot"
  Then I should see title "TestingBot - Google Search"