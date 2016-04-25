# JobLib

1) In a quick review, the code shows the following errors:
  - The code doesn't catch and throw possibles exceptions in LogMessage().
  - A file path can't have '/' in it, date must be cleaned of special characters.
  - Before try reading of file content, a wrong validation is made. The code checks if FILE DOESN'T exist, when it should ask if actually does.
  - _initialized it is never used, and must be static.
  
  Feedback and best practices:
  
  - Refactor "LogToDatabase" to "(underscore)logToDatabase". Due convention, private fields must be camel case and beggin with underscore.
  - Declare JobLogger class as static to avoid instantiation.
  - Validate if JobLogger is initialized.
  - If message null or empty throw ArgumentException
  - Set a range of levels of logging, and before logging, check whether logLevel is below JobLogger's maximum level or not. Add an "Off" 
  level also allow disable logging.
  - Use StringBuilder for memory performance.
  - Add time to logging for best registry
