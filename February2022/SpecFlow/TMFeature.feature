Feature: TMFeature
The purpose of this document is to systematically create a test report for 
Time and Materials , where the user can create TM with valid data.
@tag1
Scenario:Create time and Material record with valid data
	Given Successfully login to turn up portal.
	And Navigate to Time and Material tab.
	When Create Time and Material record.
	Then Time and Material record created successfully.

Scenario Outline:Edit time and Material record with valid data
	Given Successfully login to turn up portal.
	And Navigate to Time and Material tab.
	When Edit '<Description>','<Code>','<Price>' on existing Time and Material record
	Then '<Description>','<Code>','<Price>', should be seen in updated Time and Material record

	Examples: 
	| Description  | Code | Price |
	| February2020 | aaa  | 700   |
	| test123      | bbb  | 500   |
	| Test567      | ccc  | 600   |




