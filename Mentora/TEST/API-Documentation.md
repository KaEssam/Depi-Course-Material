# Mentora API Documentation

## Overview

The Mentora API is a RESTful API for a mentoring platform that connects mentors and mentees. This API supports user authentication, profile management, session creation, and user discovery.

**Base URL**: `https://api.mentora.com`
**API Version**: v1
**Authentication**: JWT Bearer Token

## Authentication

The API uses JWT (JSON Web Tokens) for authentication. Include the token in the `Authorization` header:

```
Authorization: Bearer <your-jwt-token>
```

**Token Expiration**: 60 minutes
**Refresh Token**: Available for token renewal

---

## API Endpoints

### Authentication Module (`/api/auth`)

#### POST /api/auth/register
Create a new user account.

**Authentication**: Not required
**Content-Type**: `application/json`

**Request Body**:
```json
{
  "email": "john.doe@example.com",
  "firstName": "John",
  "lastName": "Doe",
  "password": "SecurePass123!"
}
```

**Response** (201 Created):
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "refreshToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expiration": "2024-01-01T12:00:00Z",
  "user": {
    "id": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
    "email": "john.doe@example.com",
    "firstName": "John",
    "lastName": "Doe",
    "bio": null,
    "profileImageUrl": null,
    "title": null,
    "company": null,
    "location": null,
    "createdAt": "2024-01-01T10:00:00Z",
    "skills": null,
    "languages": null,
    "experienceYears": 0,
    "education": null,
    "socialMedia": null
  }
}
```

**Error Responses**:
- `400 Bad Request` - Validation errors
- `409 Conflict` - Email already exists

---

#### POST /api/auth/login
Authenticate user and return JWT tokens.

**Authentication**: Not required
**Content-Type**: `application/json`

**Request Body**:
```json
{
  "email": "john.doe@example.com",
  "password": "SecurePass123!"
}
```

**Response** (200 OK):
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "refreshToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expiration": "2024-01-01T12:00:00Z",
  "user": {
    "id": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
    "email": "john.doe@example.com",
    "firstName": "John",
    "lastName": "Doe",
    "bio": "Senior software engineer with 10 years of experience",
    "profileImageUrl": "https://example.com/images/profiles/john-doe.jpg",
    "title": "Senior Software Engineer",
    "company": "Tech Corp",
    "location": "San Francisco, CA",
    "createdAt": "2024-01-01T10:00:00Z",
    "skills": "JavaScript, React, Node.js, Python",
    "languages": "English, Spanish",
    "experienceYears": 10,
    "education": "BS in Computer Science",
    "socialMedia": "LinkedIn: linkedin.com/in/johndoe"
  }
}
```

**Error Responses**:
- `400 Bad Request` - Invalid credentials
- `401 Unauthorized` - Invalid email or password

---

#### POST /api/auth/refresh-token
Refresh JWT access token using refresh token.

**Authentication**: Not required
**Content-Type**: `application/json`

**Request Body**:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "refreshToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

**Response** (200 OK):
Same as login response with new tokens.

**Error Responses**:
- `400 Bad Request` - Invalid tokens
- `401 Unauthorized` - Refresh token expired

---

#### POST /api/auth/logout
Logout user and invalidate refresh token.

**Authentication**: Required
**Content-Type**: `application/json`

**Request Body**: Empty

**Response** (200 OK):
```json
{
  "message": "Logged out successfully"
}
```

**Error Responses**:
- `401 Unauthorized` - Invalid token

---

#### GET /api/auth/me
Get current authenticated user profile.

**Authentication**: Required

**Response** (200 OK):
```json
{
  "id": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
  "email": "john.doe@example.com",
  "firstName": "John",
  "lastName": "Doe",
  "bio": "Senior software engineer with 10 years of experience",
  "profileImageUrl": "https://example.com/images/profiles/john-doe.jpg",
  "title": "Senior Software Engineer",
  "company": "Tech Corp",
  "location": "San Francisco, CA",
  "createdAt": "2024-01-01T10:00:00Z",
  "skills": "JavaScript, React, Node.js, Python",
  "languages": "English, Spanish",
  "experienceYears": 10,
  "education": "BS in Computer Science",
  "socialMedia": "LinkedIn: linkedin.com/in/johndoe"
}
```

**Error Responses**:
- `401 Unauthorized` - Invalid or missing token

---

### Session Module (`/api/session`)

#### POST /api/session
Create a new mentoring session.

**Authentication**: Required
**Content-Type**: `application/json`

**Request Body**:
```json
{
  "startAt": "2024-01-15T14:30:00Z",
  "type": "OneOnOne",
  "price": 50.00,
  "notes": "Introduction to web development basics"
}
```

**Response** (201 Created):
```json
{
  "id": 123,
  "mentorId": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
  "startAt": "2024-01-15T14:30:00Z",
  "endAt": "2024-01-15T15:30:00Z",
  "status": "Scheduled",
  "type": "OneOnOne",
  "price": 50.00,
  "notes": "Introduction to web development basics"
}
```

**Session Types**:
- `OneOnOne` - One-on-one mentoring session
- `Group` - Group mentoring session
- `Workshop` - Workshop session
- `QandA` - Question and Answer session

**Session Statuses**:
- `Scheduled` - Session is scheduled
- `Pending` - Session is pending confirmation
- `Confirmed` - Session is confirmed
- `InProgress` - Session is currently in progress
- `Completed` - Session has been completed
- `Cancelled` - Session was cancelled
- `NoShow` - Mentee did not attend

**Error Responses**:
- `400 Bad Request` - Validation errors
- `401 Unauthorized` - Authentication required
- `403 Forbidden` - Insufficient permissions

---

#### GET /api/session/{id}
Get session by ID.

**Authentication**: Not required
**URL Parameters**:
- `id` (integer, required) - Session ID

**Response** (200 OK):
Same as create session response.

**Error Responses**:
- `404 Not Found` - Session not found

---

#### PUT /api/session/{id}
Update session details.

**Authentication**: Required
**URL Parameters**:
- `id` (integer, required) - Session ID
**Content-Type**: `application/json`

**Request Body**: Same as create session request

**Response** (200 OK):
Same as create session response with updated data.

**Error Responses**:
- `400 Bad Request` - Validation errors
- `401 Unauthorized` - Authentication required
- `403 Forbidden` - Not session owner
- `404 Not Found` - Session not found

---

#### DELETE /api/session/{id}
Delete a session.

**Authentication**: Required
**URL Parameters**:
- `id` (integer, required) - Session ID

**Response** (200 OK):
```json
{
  "message": "Session deleted successfully"
}
```

**Error Responses**:
- `401 Unauthorized` - Authentication required
- `403 Forbidden` - Not session owner
- `404 Not Found` - Session not found

---

### User Module (`/api/user`)

#### GET /api/user/{id}
Get user by ID.

**Authentication**: Required
**URL Parameters**:
- `id` (string, required) - User ID

**Response** (200 OK):
```json
{
  "id": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
  "email": "john.doe@example.com",
  "firstName": "John",
  "lastName": "Doe",
  "bio": "Senior software engineer with 10 years of experience",
  "profileImageUrl": "https://example.com/images/profiles/john-doe.jpg",
  "title": "Senior Software Engineer",
  "company": "Tech Corp",
  "location": "San Francisco, CA",
  "createdAt": "2024-01-01T10:00:00Z",
  "updatedAt": "2024-01-15T14:30:00Z",
  "skills": "JavaScript, React, Node.js, Python",
  "languages": "English, Spanish",
  "experienceYears": 10,
  "education": "BS in Computer Science",
  "socialMedia": "LinkedIn: linkedin.com/in/johndoe",
  "mentorSessions": [],
  "mentorBookings": [],
  "menteeBookings": []
}
```

**Error Responses**:
- `401 Unauthorized` - Authentication required
- `404 Not Found` - User not found

---

#### GET /api/user/me
Get current user's complete profile.

**Authentication**: Required

**Response** (200 OK):
Same as get user by ID, but for current authenticated user.

**Error Responses**:
- `401 Unauthorized` - Authentication required

---

#### PUT /api/user/profile
Update current user's profile.

**Authentication**: Required
**Content-Type**: `multipart/form-data` or `application/json`

**Request Body** (JSON):
```json
{
  "firstName": "John",
  "lastName": "Doe",
  "bio": "Senior software engineer with 10 years of experience",
  "title": "Senior Software Engineer",
  "company": "Tech Corp",
  "location": "San Francisco, CA",
  "skills": "JavaScript, React, Node.js, Python",
  "languages": "English, Spanish",
  "experienceYears": 10,
  "education": "BS in Computer Science",
  "socialMedia": "LinkedIn: linkedin.com/in/johndoe"
}
```

**Request Body** (Multipart Form):
```
firstName: John
lastName: Doe
bio: Senior software engineer with 10 years of experience
profileImage: [binary file data]
```

**Response** (200 OK):
```json
{
  "id": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
  "email": "john.doe@example.com",
  "firstName": "John",
  "lastName": "Doe",
  "bio": "Senior software engineer with 10 years of experience",
  "profileImageUrl": "https://example.com/images/profiles/john-doe.jpg",
  "title": "Senior Software Engineer",
  "company": "Tech Corp",
  "location": "San Francisco, CA",
  "skills": "JavaScript, React, Node.js, Python",
  "languages": "English, Spanish",
  "experienceYears": 10,
  "education": "BS in Computer Science",
  "socialMedia": "LinkedIn: linkedin.com/in/johndoe",
  "createdAt": "2024-01-01T10:00:00Z",
  "updatedAt": "2024-01-15T14:30:00Z"
}
```

**Error Responses**:
- `400 Bad Request` - Validation errors
- `401 Unauthorized` - Authentication required

---

#### GET /api/user/search
Search users with filters.

**Authentication**: Not required
**Query Parameters**:
- `query` (string, optional) - Search query for name, bio, or title
- `skills` (string, optional) - Filter by skills (comma-separated)
- `location` (string, optional) - Filter by location

**Example**:
```
GET /api/user/search?query=software%20engineer&skills=JavaScript,React&location=San%20Francisco
```

**Response** (200 OK):
```json
{
  "users": [
    {
      "id": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
      "email": "john.doe@example.com",
      "firstName": "John",
      "lastName": "Doe",
      "bio": "Senior software engineer with 10 years of experience",
      "profileImageUrl": "https://example.com/images/profiles/john-doe.jpg",
      "title": "Senior Software Engineer",
      "company": "Tech Corp",
      "location": "San Francisco, CA",
      "createdAt": "2024-01-01T10:00:00Z",
      "updatedAt": "2024-01-15T14:30:00Z",
      "skills": "JavaScript, React, Node.js, Python",
      "languages": "English, Spanish",
      "experienceYears": 10,
      "education": "BS in Computer Science",
      "socialMedia": "LinkedIn: linkedin.com/in/johndoe",
      "mentorSessions": [],
      "mentorBookings": [],
      "menteeBookings": []
    }
  ],
  "totalCount": 25
}
```

**Error Responses**:
- `400 Bad Request` - Invalid search parameters

---

## Error Response Format

All error responses follow this format:

```json
{
  "error": "Error message describing what went wrong",
  "code": "ERROR_CODE",
  "details": [
    {
      "field": "FieldName",
      "message": "Specific validation error message"
    }
  ]
}
```

**Common HTTP Status Codes**:
- `200 OK` - Request successful
- `201 Created` - Resource created successfully
- `400 Bad Request` - Validation errors or malformed request
- `401 Unauthorized` - Authentication required or invalid
- `403 Forbidden` - Insufficient permissions
- `404 Not Found` - Resource not found
- `409 Conflict` - Resource conflict (e.g., duplicate email)
- `500 Internal Server Error` - Server error

---

## Data Types

### DateTime Format
All datetime fields use ISO 8601 format: `YYYY-MM-DDTHH:mm:ssZ`

### Enum Values

**SessionType**:
- `OneOnOne`
- `Group`
- `Workshop`
- `QandA`

**SessionStatus**:
- `Scheduled`
- `Pending`
- `Confirmed`
- `InProgress`
- `Completed`
- `Cancelled`
- `NoShow`

### String Constraints
- Email: Max 255 characters, valid email format
- First Name: Max 100 characters, required
- Last Name: Max 100 characters, required
- Password: 8-100 characters, required
- Bio: Optional, max 1000 characters
- Notes: Optional, max 1000 characters

### File Upload
- Supported formats: JPEG, PNG, GIF, WebP, SVG
- Max file size: 10MB
- Profile image upload uses multipart form data

---

## JSON Schema

The complete JSON schema specification is available in `api-schema.json`. This file contains detailed validation rules for all request and response bodies and can be used for:

- Client-side validation
- API documentation generation
- Code generation
- Automated testing

---

## Rate Limiting

API requests are limited to:
- 100 requests per minute per IP address
- 1000 requests per hour per authenticated user

Rate limit headers are included in responses:
- `X-RateLimit-Limit` - Request limit
- `X-RateLimit-Remaining` - Remaining requests
- `X-RateLimit-Reset` - Reset time (Unix timestamp)

---

## CORS

The API supports Cross-Origin Resource Sharing (CORS) with the following headers:

```
Access-Control-Allow-Origin: *
Access-Control-Allow-Methods: GET, POST, PUT, DELETE, OPTIONS
Access-Control-Allow-Headers: Authorization, Content-Type
```

---

## SDKs and Libraries

Official SDKs are available for:
- JavaScript/TypeScript
- Python
- C#/.NET
- Java

Community SDKs are also available for other languages.

---

## Support

For API support and questions:
- Documentation: https://docs.mentora.com/api
- Status Page: https://status.mentora.com
- Support Email: api-support@mentora.com
- GitHub Issues: https://github.com/mentora/api/issues

---

## Changelog

### v1.0.0 (2024-01-01)
- Initial API release
- Authentication endpoints
- User management
- Session creation and management
- User search functionality