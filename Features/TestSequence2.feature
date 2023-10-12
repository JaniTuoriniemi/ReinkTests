Feature: TestSequence2

Performs a test procedure according to procedure 2

@tag1
Scenario: 1
	Given                                                                 The QR code is scanned and the browser is taken to ta emot page
	When                   Ta emot is clicked
	Then                         The browser is logged in 
Scenario: 2
	Given                                   The browser return to ta emot page
	When                           Ta emot is clicked again
	Then                                   It should now read bok registrerad
Scenario: 3
	Given                          The browser is logged out
	When                         The QR koden is scanned
	Then                              It must now read jag är klar
Scenario: 4
	Given                                             The browser is now on the page jag är klar
	When                       Click nästa and login
	Then                                       The browser is now on the page betala
Scenario: 5
	Given                                                The browser moves to the the swish payment page
	When                               The hidden test form is filled
	Then                                                            The hidden test form is read on the swish confirmation page
Scenario: 6
	Given                                              The browser is again on the page jag är klar
	When                                          Click lämna boken på en addres and login
	Then                                                   The jag är klar page with adress should be visible
Scenario: 7
	Given                                                                                                                           The nästa button is clicked and the browser is taken to the payment page where the slider is moved and phone number stated
	When                                                      The hidden test form is filled and avsluta is clicked
	Then                                                               The data from test form is read on the swish confirmation page


