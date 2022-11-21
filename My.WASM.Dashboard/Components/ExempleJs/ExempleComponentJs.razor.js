export async function getMessage() {
    await sleep(1000);
    return "Hello from JsImport";
}

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}
