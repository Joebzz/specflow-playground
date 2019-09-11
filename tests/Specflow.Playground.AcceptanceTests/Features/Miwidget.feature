Feature: Miwidget

Scenario: Can find mi-dashboard
  Given I am on the miwidgets page
  When I look for 'mi-dashboard' tag
  Then I should see a class with 'dashboard-container'