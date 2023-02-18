Feature: FinishQuizSessionQuestion
@QuizSessionAggregates

Scenario: Finish last session question
	Given The session is created with 1 questions
	When Session is started
	When Next question is started
	When Current question is finished
	Then The quiz session should have Finished State
