Feature: CreateQuizSession
@QuizSessionAggregates

Scenario: Create quiz session
	Given The session is created with start date in 3 days at 17:00, with question amount 1, with time for each question 1
	Then The quiz session should have Ready State
	Then The quiz session should have in 3 days at 17:00 Start time