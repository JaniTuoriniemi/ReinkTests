Feature: Test4

Test procedure4

@tag1
Scenario: user having no account scans an unavailable book and creates and account
	Given                                                 The user scans the book and login screen appears
	When                            User creates an new account
	Then                                                 The boken är redan upptagen screen should appear
