Here’s a comprehensive list of common **code smells**—symptoms in code that indicate potential design or implementation issues. Identifying and addressing these smells can improve code quality, maintainability, and readability.

---

### **1. Duplicated Code**
- **Description:** Same code appears in multiple places.
- **Why It's Bad:** Increases maintenance effort; bugs in one instance may exist in others.
- **Fix:** Refactor into reusable functions or modules.

---

### **2. Long Method**
- **Description:** A method or function is too long and does too much.
- **Why It's Bad:** Hard to understand, test, and maintain.
- **Fix:** Break it into smaller, single-responsibility methods.

---

### **3. Large Class**
- **Description:** A class has too many responsibilities.
- **Why It's Bad:** Violates the Single Responsibility Principle (SRP), making it hard to maintain and reuse.
- **Fix:** Split the class into smaller, more focused classes.

---

### **4. Primitive Obsession**
- **Description:** Overuse of primitive data types instead of domain-specific types.
- **Why It's Bad:** Reduces readability and increases the risk of errors.
- **Fix:** Create custom types or classes to encapsulate behavior.

---

### **5. Long Parameter List**
- **Description:** A method has too many parameters.
- **Why It's Bad:** Hard to read and understand; prone to errors.
- **Fix:** Group parameters into objects or pass a single context object.

---

### **6. Divergent Change**
- **Description:** A single class is modified in different ways for different reasons.
- **Why It's Bad:** Indicates the class has multiple responsibilities.
- **Fix:** Refactor the class into smaller, more cohesive ones.

---

### **7. Shotgun Surgery**
- **Description:** A single change requires modifications in many places.
- **Why It's Bad:** Makes code fragile and difficult to maintain.
- **Fix:** Consolidate functionality into a single location.

---

### **8. Feature Envy**
- **Description:** A class uses more methods and data from another class than its own.
- **Why It's Bad:** Indicates poor encapsulation and improper responsibilities.
- **Fix:** Move the behavior to the appropriate class.

---

### **9. Data Clumps**
- **Description:** Groups of variables that always appear together.
- **Why It's Bad:** Indicates missed opportunities for abstraction.
- **Fix:** Encapsulate the group in a class or data structure.

---

### **10. Lazy Class**
- **Description:** A class that doesn’t do enough to justify its existence.
- **Why It's Bad:** Adds unnecessary complexity.
- **Fix:** Merge it with another class or remove it.

---

### **11. Speculative Generality**
- **Description:** Code is designed for a scenario that doesn’t yet exist (YAGNI violation).
- **Why It's Bad:** Adds unnecessary complexity and makes code harder to read.
- **Fix:** Remove unused abstractions and simplify.

---

### **12. Temporary Field**
- **Description:** An object has fields that are only used in certain circumstances.
- **Why It's Bad:** Leads to confusing and error-prone code.
- **Fix:** Extract the behavior into a new class.

---

### **13. Message Chains**
- **Description:** A chain of method calls (e.g., `a.getB().getC().doSomething()`).
- **Why It's Bad:** Violates encapsulation and increases coupling.
- **Fix:** Introduce intermediary methods or simplify access patterns.

---

### **14. Middle Man**
- **Description:** A class does little more than delegate calls to another class.
- **Why It's Bad:** Adds unnecessary indirection and complexity.
- **Fix:** Remove the middleman and let clients call the delegated class directly.

---

### **15. Inappropriate Intimacy**
- **Description:** Classes depend too heavily on each other’s internal details.
- **Why It's Bad:** Violates encapsulation and increases coupling.
- **Fix:** Refactor to reduce dependencies and enforce proper boundaries.

---

### **16. Refused Bequest**
- **Description:** A subclass inherits methods or properties it doesn’t use.
- **Why It's Bad:** Indicates misuse of inheritance and breaks the Liskov Substitution Principle (LSP).
- **Fix:** Replace inheritance with composition.

---

### **17. Excessive Comments**
- **Description:** Code has too many comments explaining what it does.
- **Why It's Bad:** Often a sign of overly complex code.
- **Fix:** Refactor the code to make it self-explanatory.

---

### **18. Dead Code**
- **Description:** Code that is no longer used but still present in the codebase.
- **Why It's Bad:** Clutters the codebase and increases maintenance overhead.
- **Fix:** Remove unused code.

---

### **19. God Object / God Class**
- **Description:** A single class controls too much of the system.
- **Why It's Bad:** Violates SRP and makes the code hard to maintain.
- **Fix:** Break the class into smaller, more focused classes.

---

### **20. Circular Dependencies**
- **Description:** Classes or modules depend on each other directly or indirectly.
- **Why It's Bad:** Makes the code fragile and hard to test.
- **Fix:** Redesign dependencies to eliminate cycles.

---

### **21. Global Variables**
- **Description:** Using global variables excessively.
- **Why It's Bad:** Leads to tight coupling and unpredictable side effects.
- **Fix:** Use dependency injection or encapsulation to manage state.

---

### **22. Overly Complex Code**
- **Description:** Code has unnecessary complexity, such as deeply nested loops or over-engineered solutions.
- **Why It's Bad:** Difficult to understand, debug, and maintain.
- **Fix:** Simplify logic and use modular design.

---

### **23. Hard-Coded Values**
- **Description:** Using fixed values directly in code instead of constants or configurations.
- **Why It's Bad:** Reduces flexibility and maintainability.
- **Fix:** Replace with constants or external configuration.

---

### **24. Tight Coupling**
- **Description:** Classes or modules are too dependent on each other.
- **Why It's Bad:** Makes changes difficult and increases the risk of bugs.
- **Fix:** Use interfaces, abstractions, or dependency injection.

---

### **25. Lack of Cohesion**
- **Description:** A class or module has responsibilities that are too diverse.
- **Why It's Bad:** Reduces readability and increases the chance of bugs.
- **Fix:** Split into smaller, more focused classes or modules.

---

### **26. Improper Error Handling**
- **Description:** Failing to handle exceptions or using vague error messages.
- **Why It's Bad:** Leads to unreliable or hard-to-debug applications.
- **Fix:** Implement robust error handling with meaningful messages.

---

### Summary Table

| **Code Smell**           | **Core Problem**                                   | **Fix**                                      |
|---------------------------|---------------------------------------------------|---------------------------------------------|
| Duplicated Code           | Repeated logic                                    | Refactor into reusable functions            |
| Long Method               | Method does too much                              | Break into smaller methods                  |
| Large Class               | Too many responsibilities                         | Split into focused classes                  |
| Primitive Obsession       | Overuse of primitives                             | Use custom data types                       |
| Long Parameter List       | Too many arguments                                | Group into objects                          |
| Divergent Change          | Multiple reasons to modify a class                | Split into cohesive classes                 |
| Shotgun Surgery           | One change affects many places                   | Consolidate related code                    |
| Feature Envy              | One class relies heavily on another               | Move logic to the appropriate class         |
| Data Clumps               | Repeated groups of variables                      | Encapsulate in a class                      |
| Dead Code                 | Unused code                                       | Remove it                                   |
| God Object/Class          | Monolithic class                                  | Break into smaller classes                  |
| Tight Coupling            | Overdependence between components                 | Use abstractions or dependency injection    |

---

### How to Address Code Smells
1. **Code Reviews:** Regularly review code for potential smells.
2. **Automated Tools:** Use static analysis tools like SonarQube or linters.
3. **Refactoring:** Continuously improve the codebase by addressing smells incrementally.
4. **Follow Best Practices:** Adhere to principles like SOLID, DRY, and YAGNI.

Let me know if you'd like to dive deeper into any specific code smell or its refactoring techniques!