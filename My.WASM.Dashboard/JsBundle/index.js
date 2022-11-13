import { selectAll } from "d3-selection";
import { hello_world } from "./src/test.js"



const div = selectAll("div").style("color", "red");

for (var i = 0; i < 5; i++) {

    hello_world("truc");
}