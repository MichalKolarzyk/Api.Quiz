Feature: StartQuizSession

Scenario: Start quiz session
	Given The session is created
	When Session is started
	Then Quiz Session should change status to Started
	Then Quiz Session should change actual start time
