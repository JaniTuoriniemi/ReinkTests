Feature: Test3

Test proceduce 3 divided into subtests

@tag1
Scenario: The user is signed in whereafter the books QR code is scanned and the book is registered
	Given The Browser is directed to the login page and the user is logged in
	When The browser is directed to the book registering page as if its QR code was scanned and the nästa button is clicked
	Then The browser should now show the boken är registrerad confirmation page
Scenario: The books QR code is scanned again and the book is reported as read
	Given The browser moves to the page where it is directed to when the books QR code is scanned again and lämna boken på en adress is clicked
	When When the browser is taken to the leave book on a adress page the nästa button is clicked
	Then The browser is taken to the payment page
Scenario: The Swish payment procedure is tested
	Given The browser is on the payment page-
	When The payment test form is filled
	Then The test form is read on the Swish confirmation page
