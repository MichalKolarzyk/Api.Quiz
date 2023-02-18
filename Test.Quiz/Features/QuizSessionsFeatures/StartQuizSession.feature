Feature: StartQuizSession
@QuizSessionAggregates

Scenario: Start quiz session
	Given The session is created
	When Session is started
	Then The quiz session should have Started State
