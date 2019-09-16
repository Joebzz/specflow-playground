Feature: MIWidget

Scenario: Can find mi-dashboard
	Given I am on the miwidgets page
	When I look for 'mi-dashboard' tag
	Then I should see a class with 'dashboard-container'

Scenario: Can click on area
	Given I am on the miwidgets page
	When I click on a class 'leaflet-interactive'
	Then I should see a class with 'leaflet-popup-content'

Scenario: Can click on all areas layer
	Given I am on the miwidgets page
	When I click on a text ' All Biotoxin Production Areas'
	Then I should not see a class with 'map-info-title' 

	
Scenario: Can click on zoom
	Given I am on the miwidgets page
	When I click on a class 'leaflet-control-zoom-in'
	Then I should able to see a style with 'scale(128)' 

Scenario: Can click on zoom out
	Given I am on the miwidgets page
	When I click on a class 'leaflet-control-zoom-out'
	Then I should see a style with 'scale(32)'
