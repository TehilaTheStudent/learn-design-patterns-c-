In the context of **design patterns**, **aggregation** is often compared with **composition** as part of object-oriented design. Here's a breakdown of **Aggregation vs Composition**:

| **Aspect**           | **Aggregation**                                                  | **Composition**                                                |
|-----------------------|------------------------------------------------------------------|----------------------------------------------------------------|
| **Definition**        | A "has-a" relationship where one object contains another, but the contained object can exist independently. | A "has-a" relationship where one object owns another, and the contained object cannot exist independently. |
| **Dependency**        | Looser coupling; the lifetime of the contained object is independent of the container. | Stronger coupling; the lifetime of the contained object depends on the container. |
| **Example**           | A `Car` has `Wheels`, but the `Wheels` can exist separately.    | A `House` has `Rooms`, and the `Rooms` cannot exist without the `House`. |
| **UML Representation**| Represented by a hollow diamond at the aggregate side.          | Represented by a filled diamond at the composite side.         |
| **Usage in Patterns** | Found in patterns like **Observer** (e.g., `Observers` aggregated in `Subject`). | Found in patterns like **Builder** or **Composite**.           |

### In Design Patterns
- **Aggregation** often appears when objects work together but retain their own lifecycle, promoting loose coupling (e.g., **Mediator**, **Observer**).
- **Composition** is used when an object is inherently part of another, ensuring strong coupling and lifecycle control (e.g., **Composite**, **Decorator**).

---
motivation for factories: hide the creation and implementation behind interfaces, so we can change the concrete without changing the client code    