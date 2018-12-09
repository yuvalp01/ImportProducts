
Installation steps:

1. Build the solution in release mode
2. Run the getapp_import.exe from ..\bin\Release. e.g.:
getapp_import capterra feed-products/capterra.yaml


How to run the unit tests:

1. In the "TestProvider" class, change the path the point to the location of your "feed-products" folder.
2. Run all test


My comments:

1. The json serialization is obviously not optimal. I would have made it shorter and cleaner.

2. I would have written more conditions to minimize the chance to fall into an exception that produce only generic message.

3. I would have implemented a logger

4. I would have created an installer with a wizard the set the path to the json/yaml files at the beginning.



