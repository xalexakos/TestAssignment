Feature: Registration
Registration page verification

    Scenario: A user cannot register with empty form
        Given user visits the registration page
        When a user is registered with the following details
          | First Name | Last Name | Address | City | State | Zip Code | Phone | SSN | Username | Password | Password confirmation |
          |            |           |         |      |       |          |       |     |          |          |                       |
        Then the registration error First name is required. is displayed
        And the registration error Last name is required. is displayed
        And the registration error Address is required. is displayed
        And the registration error City is required. is displayed
        And the registration error State is required. is displayed
        And the registration error Zip Code is required. is displayed
        And the registration error Social Security Number is required. is displayed
        And the registration error Username is required. is displayed
        And the registration error Password is required. is displayed
        And the registration error Password confirmation is required. is displayed
        And the registration is not completed

    Scenario: A user cannot register with missing required fields
        Given user visits the registration page
        When a user is registered with the following details
          | First Name | Last Name | Address | City | State | Zip Code | Phone     | SSN | Username | Password | Password confirmation |
          | Test       | User      |         |      |       |          | 123456789 |     | testuser | testpass | testpass              |
        Then the registration error Address is required. is displayed
        And the registration error City is required. is displayed
        And the registration error State is required. is displayed
        And the registration error Zip Code is required. is displayed
        And the registration error Social Security Number is required. is displayed
        And the registration is not completed

    Scenario: A user cannot register with invalid password confirmation
        Given user visits the registration page
        When a user is registered with the following details
          | First Name | Last Name | Address   | City      | State      | Zip Code | Phone     | SSN       | Username | Password | Password confirmation |
          | Test       | User      | Test addr | Test city | Test state | 12345    | 123456789 | 123456789 | testuser | testpass | testpass1             |
        Then the registration error Passwords did not match. is displayed
        And the registration is not completed

    Scenario: A user cannot register with an existing username
        Given a user with username testuser
        And user visits the registration page
        When a user is registered with the following details
          | First Name | Last Name | Address   | City      | State      | Zip Code | Phone     | SSN       | Username | Password | Password confirmation |
          | Test       | User      | Test addr | Test city | Test state | 12345    | 123456789 | 123456789 | testuser | testpass | testpass              |
        Then the registration error This username already exists. is displayed
        And the registration is not completed

    Scenario: User registration success
        Given user visits the registration page
        When a user is registered with the following details
          | First Name | Last Name | Address   | City      | State      | Zip Code | Phone | SSN       | Username    | Password | Password confirmation |
          | Test       | User      | Test addr | Test city | Test state | 12345    |       | 123456789 | iamanewuser | testpass | testpass              |
        Then the registration is completed
