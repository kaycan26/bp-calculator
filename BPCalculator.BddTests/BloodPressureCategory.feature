Feature: Blood pressure category
  In order to understand my blood pressure
  As a patient
  I want to see the correct category for my readings

  Scenario Outline: Categorise blood pressure
    Given a systolic value of <Systolic>
    And a diastolic value of <Diastolic>
    When I calculate the blood pressure category
    Then the result should be <Category>

    Examples:
      | Systolic | Diastolic | Category |
      | 90       | 60        | Ideal    |
      | 110      | 70        | Ideal    |
      | 135      | 85        | PreHigh  |
      | 150      | 95        | High     |
