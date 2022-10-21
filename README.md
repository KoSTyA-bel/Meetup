# Meetup

This service is needed to work with meetups. To work with some methods of this service, authorization using a JWT is required. To get JWT, use: <b>https://github.com/KoSTyA-bel/Auth</b>


<h2>Methods</h2>

| Method name | Request type | Authorization required | Desciption |
| - | - | - | - |
| GetById | GET | - | Returns meetup with specific id |
| Get-range | GET | - | Returns range of meeetups |
| Create-meetup | POST | + | Creates new meetup |
| Update-meetup | PUT | + | Updates meetup data |
| Delete | DELETE | + | Deletes meetup |

<h2>Ways to start the service</h2>

<h3>docker-compose</h3>

Go to the ./devops directory and run next command:

```
docker-compose up
```

After starting the container, you can send a request to the service.

Request url:

```
http://localhost:80/api/Meetup/
```


<h3>Normal startup</h3>

After building the project, run it. After a successful launch, you can send a request to the service.

```
http://your_url/api/Meetup/
```

<h2>Example of requests</h2>

<h2>GetById:</h2>

```
GET: http://localhost:80/api/Meetup/ddfe7892-a5b5-40a9-9c55-96c3e3d4e1ab
```

Returns:

```
If service has meeting with the passed id:
    Status code: 200
    Response body:
        {
            "id": "string",
            "name": "string",
            "desciption": "string",
            "speaker": "string",
            "date": "string",
            "place": "string"
        }

If service has not meeting with the passed id:
    Status code: 204

If id is bad:
    Status code: 400
```

<h2>Get-Range:</h2>

```
GET: http://localhost:80/api/Meetup/Get-range
GET: http://localhost:80/api/Meetup/Get-range?pageSize=1
GET: http://localhost:80/api/Meetup/Get-range?page=1
GET: http://localhost:80/api/Meetup/Get-range?page=1&pageSize=1
```

Returns:

```
If there were no internal errors:
    Status code: 200
    Response body: 
        [
            {
                "id": "string",
                "name": "string",
                "desciption": "string",
                "speaker": "string",
                "date": "string",
                "place": "string"
            }
        ]

If there was an internal errorЖ
    Status code: 500
```

<h2>Create-meetup:</h2>

```
POST: http://localhost:80/api/Meetup/Create-meetup
Body:
    {
        "id": "string", (Guid)
        "name": "string",
        "desciption": "string",
        "speaker": "string",
        "date": "string", (In UTC(ex: 21.10.2022 23.00.00 UTC))
        "place": "string"
    }
```

Returns:

```
If meetup was successfully created:
    Status code: 200
    Body: Guid (ex. 3fa85f64-5717-4562-b3fc-2c963f66afa6)

If your JWT is bad:
    Status code: 401

If there was an internal error:
    Status code: 500
```

<h2>Update-meetup:</h2>

```
PUT: http://localhost:80/api/Meetup/Update-meetup
Body:
    {
        "id": "string", (Guid)
        "name": "string",
        "desciption": "string",
        "speaker": "string",
        "date": "string", (In UTC(ex: 21.10.2022 23.00.00 UTC))
        "place": "string"
    }
```

Returns:

```
If meetup data was successfully changed:
    Status code: 200

Meeting does not exist:
    Status code: 400

If your JWT is bad:
    Status code: 401

If there was an internal error:
    Status code: 500
```

<h2>Delete:</h2>

```
DELETE: http://localhost:80/api/Meetup/ddfe7892-a5b5-40a9-9c55-96c3e3d4e1ab
```

Returns:

```
If the deleting was successful:
    Status code: 200

If your JWT is bad:
    Status code: 401

If there was an internal error:
    Status code: 500
```