<<<<<<< HEAD
import { FigureColor } from './chess/figureColor.js';
import { ChessDesk } from './chess/chessDesk.js';
import {init} from './chess/dragDrop.js';
class PlayerDesk{
    constructor(deskId){
        let deskElement = document.getElementById(deskId);
        this.chessDesk = new ChessDesk(deskElement);
    }
}
globalThis.playerDesk = new PlayerDesk("chessTable");
globalThis.playerDesk.chessDesk.currentPlayer = FigureColor.white;
init(playerDesk.chessDesk.desk,true);
=======
//import { CellPoint } from "./chess/CellPoint.js";
//import { FigureColor } from "./chess/FigureColor.js";
//import { MoveState } from "./chess/MoveState.js";
//import { CSSCellState } from "./chess/CSSCellState.js";
//import { Figure } from "./chess/Figure.js";
//import { Bishop } from "./chess/Bishop.js";
//import { Horse } from "./chess/Horse.js";
//import { King } from "./chess/King.js";
//import { Pawn } from "./chess/Pawn.js";
//import { Queen } from "./chess/Queen.js";
//import { Rook } from "./chess/Rook.js";
//import { ChessCell } from "./chess/ChessCell.js";
import { ChessDesk, chessDesk } from "./chess/ChessDesk.js";
//import { CanMoveDestination } from "./chess/CanMoveDestination.js";
import { appendDIV } from "./chess/Tools.js";

function drawChessTableOutside(htmlElement){
    for (let s of ['', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', '']) {
        appendDIV(htmlElement, "gripDeskRow", s);
    }
    appendDIV(htmlElement, "gripDeskColumn", "1");
    var mainChessTable = appendDIV(htmlElement, "chessCelsTable", "");
    for (let s of ["1", "2", "2", "3", "3", "4", "4", "5", "5", "6", "6", "7", "7", "8", "8"]) {
        appendDIV(htmlElement, "gripDeskColumn", s);
    }
    for (let s of ['', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', '']) {
        appendDIV(htmlElement, "gripDeskRow", s);
    }
    return mainChessTable;
}


 
// initial chess desk
var htmlElement = document.getElementById("chessDesk");
// chessTable 
//var chessTableElement = appendDIV(htmlElement, "chessTable", "");
var chessTableElement = drawChessTableOutside(appendDIV(htmlElement, "chessTable", ""));
for (let i = 0; i < 8; i++) {
    for (let j = 0; j < 8; j++) {
        let cellElement = appendDIV(chessTableElement, "chessCell", "");
        if ((i + j) % 2) cellElement.classList.add("blackCell");
        cellElement.id = "cell" + i + j;
    }
}

// Player Desk
var playerDeskElement = appendDIV(htmlElement, "playerDesk", "");

appendDIV(playerDeskElement, "userBlackDashBoard userDashBoard", "");
appendDIV(playerDeskElement, "userWhiteDashBoard userDashBoard", "");

//ajax get desk
let xhttp = new XMLHttpRequest();

xhttp.timeout = 9000;
xhttp.open("GET", "/Chess?handler=desk", true);
xhttp.setRequestHeader('Content-Type','application/json');
xhttp.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
xhttp.onload = function () {
    if (xhttp.status === 0) {
        var desk = JSON.parse(xhttp.responseText);
        chessDesk.refreshDesk();
    }
};
xhttp.onreadystatechange = function () {
    // In local files, status is 0 upon success in Mozilla Firefox
    if (xhttp.readyState === XMLHttpRequest.DONE) {
        var status = xhttp.status;
        if (status === 0 || (status >= 200 && status < 400)) {
            // The request has been completed successfully
            console.log(xhttp.response);
        } else {
            // Oh no! There has been an error with the request!
        }
    }
};
xhttp.send();


// initial chess desk
//chessDesk.refreshDesk(); 





>>>>>>> 82450a9967dec9571d814c78bd55f23821904074
