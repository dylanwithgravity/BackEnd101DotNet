# Books Resource

## Paths

### GET /books

#### Parameters

#### Responses

### GET /books/{id}

#### Parameters

Id: in the url

#### Responses

200 Ok
Formatted as application/json

```json
{
   "id": 1,
   "title":  "Some Title",
   "author": "Some Author",
   "genre": "Fiction"
}

```

404 Not Found
