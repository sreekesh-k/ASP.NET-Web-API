# ASP.NET-Web-API

 Contains Simple Web Api built using asp dot net core web api

# Items API Documentation

## Base URL:

`https://demos.sreekeshkprabhu.me/api/items`

---

## Endpoints

### 1. Get All Items

**Description:** Retrieves a list of all items.
**Endpoint:** `GET /api/items`
**Response:**

```json
[
  {
    "id": 1,
    "name": "Item A",
    "quantity": 10,
    "description": "Description for Item A"
  },
  {
    "id": 2,
    "name": "Item B",
    "quantity": 5,
    "description": "Description for Item B"
  }
]
```

---

### 2. Get Item by ID

**Description:** Retrieves a specific item by its ID.**Endpoint:** `GET /api/items/{id}`**Path Parameter:**

- **id** *(integer)*: The unique identifier of the item.

**Response:**

- **200 OK**

```json
{
  "id": 1,
  "name": "Item A",
  "quantity": 10,
  "description": "Description for Item A"
}
```

- **404 Not Found**

```json
{
  "error": "Item not found"
}
```

---

### 3. Create a New Item

**Description:** Creates a new item.
**Endpoint:** `POST /api/items`
**Request Body:**

```json
{
  "name": "Item A",
  "quantity": 10,
  "description": "Description for Item A"
}
```

**Response:**

- **201 Created**

```json
{
  "id": 1,
  "name": "Item A",
  "quantity": 10,
  "description": "Description for Item A"
}
```

---

### 4. Update an Existing Item

**Description:** Updates the details of an existing item.**Endpoint:** `PUT /api/items/{id}`**Path Parameter:**

- **id** *(integer)*: The unique identifier of the item.

**Request Body:**

```json
{
  "name": "Updated Item A",
  "quantity": 15,
  "description": "Updated description for Item A"
}
```

**Response:**

- **204 No Content**
- **404 Not Found**

```json
{
  "error": "Item not found"
}
```

---

### 5. Delete an Item

**Description:** Deletes an item by its ID.**Endpoint:** `DELETE /api/items/{id}`**Path Parameter:**

- **id** *(integer)*: The unique identifier of the item.

**Response:**

- **204 No Content**
- **404 Not Found**

```json
{
  "error": "Item not found"
}
```

---

## Notes

- Use tools like Postman, cURL, or Swagger for testing the API.
