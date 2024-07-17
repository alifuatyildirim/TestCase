Feature: CreateActivityCommand

    Scenario: Create Activity with POST Request.Then http status should be OK
        Given Users are
          | Id                                   | Name     | Email                 | JoinDate         |
          | 22222222-2222-2222-2222-222222222222 | Fuat     | fuat@fuat.com         | CURRENT_DATETIME |
          | 33333333-3333-3333-3333-333333333333 | Ali Fuat | yildirim@yildirim.com | CURRENT_DATETIME |
        When POST "/activities" is called with parameters
          | Name | Email       | ActivityType | Description | UserId |
          | Ali  | ali@ali.com | Signup       | Test-1      |        |
        Then Http status code should be 200 and Message should be "" and error code should be ""
        Then Users should be
          | Name     | Email                 | JoinDate         |
          | Ali      | ali@ali.com           | CURRENT_DATETIME |
          | Ali Fuat | yildirim@yildirim.com | CURRENT_DATETIME |
          | Fuat     | fuat@fuat.com         | CURRENT_DATETIME |
