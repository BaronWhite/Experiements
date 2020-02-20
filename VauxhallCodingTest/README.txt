Hello,

I'll provide a quick explanation of my code.
I timed the different tasks to keep to the 2 hour limit, but due to interruptions these are not 100% accurate.


1. CustomerService Refactoring Input Validation ~30 minutes

Firstly, I moved the validation logic into their separate methods.
There are several ways to handle the validation, but I found it useful to have the methods return a string with an error message in case of validation failure, and to have a ValidationResult class, to keep track of all the errors, that can be later returned to the user.
This is a good way of letting the user know of more than one problem with the input (if all inputs are wrong, the user might have to try several times until everything is is corrected, this way, all errors are identified in one go).

There must be more elegant ways of implementing the validation with the ValidationResult class, or even extracting the validation to another class, but here is not enough code to justify the latter other than to "prove a point".
Ideally, these would be private, to abstract the inner logic, but for easiness of individual testing these were left as public. A solution would be to extract into another class, where callers of CustomerService would then have no visual of these.

2. CustomerService Refactoring Credit Check ~60 minutes

For this I implemented a factory design pattern, this keeps the validation method very short, instead of being cluttered with a chain of if-else or a big switch, and makes it more easy to add new types.
Additionally, when editing one of the types, it is impossible to accidentally affect one of the others, as they are kept separate.
The inferface, classes and factory were all put into CustomerCreditCheck for easiness.

3. Testing ~45 minutes

There currently are 2 testing projects. I created "Tests" with VS 2017, however this is incompatible with older versions of VS, I just quickly added another project "TestsOldVer" and copied the code over.
The individual validation methods are tested for valid and invalid input. Usually each test should contain one individual scenario, but to save time multiple all failure scenarios were tested in TestValidateEmail/TestValidateName.

Ideally, the validation methods should be made private and the public AddCustomer method tested.

The tests for validating credit checks (currently empty) could also be put into a seperate class to test the validation methods.