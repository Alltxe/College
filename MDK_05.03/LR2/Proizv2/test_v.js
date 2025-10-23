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

// Helper function to calculate expected result: x*sin(3x)
function calculateExpectedResult(x) {
    return x * Math.sin(3 * x);
}

// Basic validation
pm.test("Response status code is 200 for valid input", function () {
    pm.expect(pm.response.code).to.equal(200);
});

pm.test("Response has the correct structure", function () {
    const responseJson = pm.response.json();
    pm.expect(responseJson).to.be.an('object');
    pm.expect(responseJson).to.have.property('result');
    pm.expect(responseJson.result).to.be.a('number');
});

// Verify the result for the current request
pm.test("Result is correctly calculated for x = 123", function () {
    const responseJson = pm.response.json();
    const x = 123;
    const expectedResult = calculateExpectedResult(x);
    pm.expect(responseJson.result).to.be.approximately(expectedResult, 0.0001);
});

// Test with positive value
testWithValue(10, 200, "Positive value (x = 10)", function(response) {
    const responseJson = response.json();
    pm.test("Result is correct for positive value (x = 10)", function() {
        const expectedResult = calculateExpectedResult(10);
        pm.expect(responseJson.result).to.be.approximately(expectedResult, 0.0001);
    });
});

// Test with negative value
testWithValue(-5, 200, "Negative value (x = -5)", function(response) {
    const responseJson = response.json();
    pm.test("Result is correct for negative value (x = -5)", function() {
        const expectedResult = calculateExpectedResult(-5);
        pm.expect(responseJson.result).to.be.approximately(expectedResult, 0.0001);
    });
});

// Test with zero
testWithValue(0, 200, "Zero value (x = 0)", function(response) {
    const responseJson = response.json();
    pm.test("Result is correct for zero value (x = 0)", function() {
        pm.expect(responseJson.result).to.be.approximately(0, 0.0001);
    });
});

// Edge cases - Very small and very large values
testWithValue(0.0001, 200, "Very small positive value", function(response) {
    const responseJson = response.json();
    pm.test("Result is correct for very small positive value", function() {
        const expectedResult = calculateExpectedResult(0.0001);
        pm.expect(responseJson.result).to.be.approximately(expectedResult, 0.0001);
    });
});

testWithValue(-0.0001, 200, "Very small negative value", function(response) {
    const responseJson = response.json();
    pm.test("Result is correct for very small negative value", function() {
        const expectedResult = calculateExpectedResult(-0.0001);
        pm.expect(responseJson.result).to.be.approximately(expectedResult, 0.0001);
    });
});

testWithValue(1e6, 200, "Very large positive value", function(response) {
    const responseJson = response.json();
    pm.test("Result is correct for very large positive value", function() {
        const expectedResult = calculateExpectedResult(1e6);
        pm.expect(responseJson.result).to.be.approximately(expectedResult, 0.1);
    });
});

testWithValue(-1e6, 200, "Very large negative value", function(response) {
    const responseJson = response.json();
    pm.test("Result is correct for very large negative value", function() {
        const expectedResult = calculateExpectedResult(-1e6);
        pm.expect(responseJson.result).to.be.approximately(expectedResult, 0.1);
    });
});

// Special values - Where sin(3x) is 0, 1, or -1
testWithValue(Math.PI/3, 200, "Special value where sin(3x) = 0", function(response) {
    const responseJson = response.json();
    pm.test("Result is correct for x = π/3 (sin(3x) = 0)", function() {
        pm.expect(responseJson.result).to.be.approximately(0, 0.0001);
    });
});

testWithValue(Math.PI/6, 200, "Special value where sin(3x) = 1", function(response) {
    const responseJson = response.json();
    pm.test("Result is correct for x = π/6 (sin(3x) = 1)", function() {
        const expectedResult = Math.PI/6;
        pm.expect(responseJson.result).to.be.approximately(expectedResult, 0.0001);
    });
});

// Fix for the 5π/6 test case - the expected result should be negative
testWithValue(5*Math.PI/6, 200, "Special value where sin(3x) = -1", function(response) {
    const responseJson = response.json();
    pm.test("Result is correct for x = 5π/6 (sin(3x) = -1)", function() {
        // 5π/6 * sin(3 * 5π/6) = 5π/6 * sin(5π/2) = 5π/6 * -1 = -5π/6
        const expectedResult = -5*Math.PI/6;
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

// Basic HTTP validation
pm.test("Response time is acceptable", function () {
    pm.expect(pm.response.responseTime).to.be.below(1000);
});

pm.test("Content-Type header is application/json", function () {
    pm.expect(pm.response.headers.get('Content-Type')).to.include('application/json');
});