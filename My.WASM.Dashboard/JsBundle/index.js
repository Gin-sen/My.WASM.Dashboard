import { selectAll } from "d3-selection";
import { hello_world } from "./src/test.js"



const div = selectAll("div").style("color", "red");

export function test() {
    for (var i = 0; i < 5; i++) {
        hello_world("truc");
    }
}

export function getMessage() {
    return "Hello from JsImport"
}

test()