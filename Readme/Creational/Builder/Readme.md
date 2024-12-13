
 1. extend the BaseHouse for every different house
![alt text](image.png)
 2. create ugly ctor
![alt text](image-1.png)
![alt text](image-5.png)

solution:
dedicated class for "building" logic
![alt text](image-2.png)
![alt text](image-3.png)
![alt text](image-4.png)

![alt text](image-6.png)
![alt text](image-7.png)

![alt text](image-8.png)
![alt text](image-9.png)

fluent syntax can be used to create fake objects for unit testing- with chaning set methods and implicit conversion

different builders implementation can give same object that was built in different ways, and can give 2 different objects, but than they can be retrieved only from the builders themselves, not from the director couse its not in the IBuilder


![alt text](image-10.png)

particular motivation: complex-to-create  objects

### how to extend? (same product different building logic)

1. **Create a New Builder:**
   - Implement `ITaskBuilder` or `IFluentTaskBuilder` for the new task type (e.g., `ResearchTaskBuilder`).

2. **Define Custom Build Logic:**
   - Override methods like `SetX()` and `BuildTask()` to set properties specific to the new task.

3. **Update the TaskDirector (Optional):**
   - Pass the new builder to `TaskDirector` if it needs to use the builder.

