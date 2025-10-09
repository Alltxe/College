function testWithValue(x, expectedStatus, description, additionalTests) {
    const requestBody = { x: x };
    
    pm.sendRequest({
        url: pm.request.url.toString(),
        method: 'POST',
        header: pm.request.headers,
        body: {
            mode: 'raw',
            raw: JSON.stringify(requestBody),
            options: { raw: { language: 'json' } }
        }
    }, function (err, response) {
        pm.test(`${description} - Status code is ${expectedStatus}`, function() {
            pm.expect(response.code).to.equal(expectedStatus);
        });
        
        if (additionalTests && typeof additionalTests === 'function') {
            additionalTests(response);
        }
    });
}

// 1. VALID INPUTS - Test with different positive values
pm.test("Response status code is 200 for valid input", function () {
    pm.expect(pm.response.code).to.equal(200);
});

pm.test("Response has the correct structure", function () {
    const responseJson = pm.response.json();
    pm.expect(responseJson).to.be.an('object');
    pm.expect(responseJson).to.have.property('result');
    pm.expect(responseJson.result).to.be.a('number');
});

// Verify the result for the current request (assuming x = 123)
pm.test("Result is correctly calculated for x = 123", function () {
    const responseJson = pm.response.json();
    const x = 123;
    const expectedResult = Math.log(x);
    pm.expect(responseJson.result).to.be.approximately(expectedResult, 0.0001);
});

// 2. EDGE CASES - Very small positive values
testWithValue(0.0001, 200, "Very small positive value (0.0001)", function(response) {
    const responseJson = response.json();
    pm.test("Result is correct for very small value (0.0001)", function() {
        const expectedResult = Math.log(0.0001);
        pm.expect(responseJson.result).to.be.approximately(expectedResult, 0.0001);
    });
});

// Test with value close to zero
testWithValue(1e-10, 200, "Value very close to zero (1e-10)", function(response) {
    const responseJson = response.json();
    pm.test("Result is correct for value very close to zero (1e-10)", function() {
        const expectedResult = Math.log(1e-10);
        pm.expect(responseJson.result).to.be.approximately(expectedResult, 0.0001);
    });
});

// Test with value = 1 (ln(1) = 0)
testWithValue(1, 200, "Value = 1 (ln(1) = 0)", function(response) {
    const responseJson = response.json();
    pm.test("Result is correct for value = 1 (should be 0)", function() {
        pm.expect(responseJson.result).to.be.approximately(0, 0.0001);
    });
});

// Test with e (natural logarithm base)
testWithValue(Math.E, 200, "Value = e (ln(e) = 1)", function(response) {
    const responseJson = response.json();
    pm.test("Result is correct for value = e (should be 1)", function() {
        pm.expect(responseJson.result).to.be.approximately(1, 0.0001);
    });
});

// Test with very large value
testWithValue(1e10, 200, "Very large value (1e10)", function(response) {
    const responseJson = response.json();
    pm.test("Result is correct for very large value (1e10)", function() {
        const expectedResult = Math.log(1e10);
        pm.expect(responseJson.result).to.be.approximately(expectedResult, 0.0001);
    });
});

// 3. INVALID INPUTS - Test with x <= 0
// Test with x = 0
testWithValue(0, 400, "Invalid input (x = 0)", function(response) {
    pm.test("Error message is provided for x = 0", function() {
        const responseJson = response.json();
        pm.expect(responseJson).to.have.property('message');
        pm.expect(responseJson.message).to.include('must be > 0');
    });
});

// Test with negative value
testWithValue(-1, 400, "Invalid input (x = -1)", function(response) {
    pm.test("Error message is provided for negative x", function() {
        const responseJson = response.json();
        pm.expect(responseJson).to.have.property('message');
        pm.expect(responseJson.message).to.include('must be > 0');
    });
});

// Test with large negative value
testWithValue(-1000, 400, "Invalid input (x = -1000)", function(response) {
    pm.test("Error message is provided for large negative x", function() {
        const responseJson = response.json();
        pm.expect(responseJson).to.have.property('message');
        pm.expect(responseJson.message).to.include('must be > 0');
    });
});

// 4. ADDITIONAL TEST CASES
// Test with decimal value
testWithValue(3.14, 200, "Decimal value (3.14)", function(response) {
    const responseJson = response.json();
    pm.test("Result is correct for decimal value (3.14)", function() {
        const expectedResult = Math.log(3.14);
        pm.expect(responseJson.result).to.be.approximately(expectedResult, 0.0001);
    });
});

// Test with integer value
testWithValue(42, 200, "Integer value (42)", function(response) {
    const responseJson = response.json();
    pm.test("Result is correct for integer value (42)", function() {
        const expectedResult = Math.log(42);
        pm.expect(responseJson.result).to.be.approximately(expectedResult, 0.0001);
    });
});

// Test with fractional value
testWithValue(0.5, 200, "Fractional value (0.5)", function(response) {
    const responseJson = response.json();
    pm.test("Result is correct for fractional value (0.5)", function() {
        const expectedResult = Math.log(0.5);
        pm.expect(responseJson.result).to.be.approximately(expectedResult, 0.0001);
    });
});

// Test with power of 10
testWithValue(100, 200, "Power of 10 (100)", function(response) {
    const responseJson = response.json();
    pm.test("Result is correct for power of 10 (100)", function() {
        const expectedResult = Math.log(100);
        pm.expect(responseJson.result).to.be.approximately(expectedResult, 0.0001);
    });
});

// Test with non-numeric input
pm.sendRequest({
    url: pm.request.url.toString(),
    method: 'POST',
    header: pm.request.headers,
    body: {
        mode: 'raw',
        raw: JSON.stringify({ x: "not-a-number" }),
        options: { raw: { language: 'json' } }
    }
}, function (err, response) {
    pm.test("Non-numeric input should return error status code", function() {
        pm.expect(response.code).to.be.oneOf([400, 500]);
    });
    
    pm.test("Error response for non-numeric input has error details", function() {
        const responseJson = response.json();
        pm.expect(responseJson).to.satisfy(function(json) {
            return json.hasOwnProperty('message') || 
                   json.hasOwnProperty('errors') ||
                   (json.hasOwnProperty('type') && json.hasOwnProperty('title'));
        });
    });
});

// Test with missing x parameter
pm.sendRequest({
    url: pm.request.url.toString(),
    method: 'POST',
    header: pm.request.headers,
    body: {
        mode: 'raw',
        raw: JSON.stringify({}),
        options: { raw: { language: 'json' } }
    }
}, function (err, response) {
    pm.test("Missing x parameter should return error status code", function() {
        pm.expect(response.code).to.be.oneOf([400, 500]);
    });
    
    pm.test("Error response for missing parameter has error details", function() {
        const responseJson = response.json();
        pm.expect(responseJson).to.satisfy(function(json) {
            return json.hasOwnProperty('message') || 
                   json.hasOwnProperty('errors') ||
                   (json.hasOwnProperty('type') && json.hasOwnProperty('title'));
        });
    });
});

// Test with additional parameters (should be ignored)
testWithValue(10, 200, "Additional parameters should be ignored", function(response) {
    pm.sendRequest({
        url: pm.request.url.toString(),
        method: 'POST',
        header: pm.request.headers,
        body: {
            mode: 'raw',
            raw: JSON.stringify({ x: 10, extraParam: "should be ignored" }),
            options: { raw: { language: 'json' } }
        }
    }, function (err, extraParamResponse) {
        pm.test("Extra parameters should not affect the result", function() {
            const expectedResult = response.json().result;
            const actualResult = extraParamResponse.json().result;
            pm.expect(actualResult).to.equal(expectedResult);
        });
    });
});

pm.test("Response time is acceptable", function () {
    pm.expect(pm.response.responseTime).to.be.below(1000);
});

pm.test("Content-Type header is application/json", function () {
    pm.expect(pm.response.headers.get('Content-Type')).to.include('application/json');
});