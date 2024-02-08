# LatencyAPI

This is a .NET Core application designed to measure latency between calls to a specified URI.

## Overview

The LatencyAPI application consists of a controller named `LatencyController` and a service named `LatencyService`. The controller handles HTTP requests and routes them to appropriate actions, while the service performs the actual latency measurement logic.

## Controller

The `LatencyController` is responsible for receiving HTTP requests and routing them to the appropriate service methods.

### Actions

- **GET /Latency/**: Returns an OK response with status code 200.
- **POST /Latency/**: Initiates latency testing by making multiple calls to a specified URI with a specified delay between calls.

#### Request Parameters

- `requestUri`: The URI to test latency against.
- `numCalls`: The number of calls to make to the specified URI.
- `delayInMillis`: The delay in milliseconds between each call.

## Service

The `LatencyService` contains the logic for measuring latency by making HTTP requests to the specified URI.

### Methods

- **TestLatencyPostAsync**: Performs latency testing by making multiple asynchronous HTTP requests to the specified URI and calculates the average latency.

## Dockerfile

The Dockerfile provided is used to build a Docker image for the LatencyAPI application.

## Example Usage

To test latency, you can make a POST request using tools like cURL:

```bash
curl -X POST \
  'http://{{url}}/Latency?requestUri={{url}}Latency&numCalls=20&delayInMillis=0' \
  --header 'Accept: */*'
```

- Replace {{url}} with the actual URL you want to test latency against.