Feature: Test1_sammanslagen

This is test scenario 1 where the user creates and deletes an account.A short summary of the feature

@tag1
Scenario: The user creates and then deletes account
	Given                   Account is created
	When                   Account is deleted
	Then                                       It is verified that account is deleted
