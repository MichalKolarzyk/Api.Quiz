Feature: FinishQuizSessionQuestion

Scenario: Finish last session question
	Given The session is created with 1 questions
	When Session is started
	When Next question is started
	When Current question is finished
	Then Quiz Session should have status Finished
