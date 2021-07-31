SeleniumExample - Using Selenium with C#.NET
===============

1. Use the Visual Studio. Add extensions NUnit and Test Explorer.
2. Tests are in the class [a relative link](MainScenarios.cs)
3. Test plan is in the word document TestPlan-AutomationPractice.docx

---
## NOTE 1
We have user credentials in [App.config](/GuiTests/App.config) file.
There is created user with email mr.goodman@mozart.symphony under the key UserEmail.
This user is used for all tests except test CreateAccount because we can't create another account with same email.

---
## NOTE 2
We have email under the key TemporaryEmail under the [App.config](/GuiTests/App.config) file.
This email is used in test run CreateAccount.
When account is created once, we are not able to delete it (at least I didn't find a way) so we have to change TemporaryEmail each time after test CreateAccount runs.
This is the reason why I called it TemporaryEmail and you can just change last part of email (increase integer end of the string by 1).
If I had more time I could automate this part also (to create txt file in which on each CreateAccount test run we update email and use updated value). This is still in to do.
