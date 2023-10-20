Feature: Test7

Tests that it is possible to send a message to another account.

@tag1
Scenario: Goes to a message thread to send a message and verifies it is posted
	Given                                           User loggs in and goes to a message thread
	When                                                           A message containing a random number is sent to the thread
	Then                                          It is verified that the message is posted
