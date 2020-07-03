﻿//import { } from "./CSSCellState.js";
//import { FigureColor } from "./FigureColor.js";
//import { ChessCell } from "./ChessCell.js";
//import { Bishop } from "./Bishop.js";
//import { Horse } from "./Horse.js";
//import { King } from "./King.js";
//import { Pawn } from "./Pawn.js";
//import { Queen } from "./Queen.js";
//import { Rook } from "./Rook.js";

//import { appendDIV } from "./chess/Tools.js";
import { Figure, FigureType } from "./Figure.js";
import { FigureColor } from "./FigureColor.js";
import { CSSCellState } from "./CSSCellState.js";


export function getCellElementByIndex(row, cell) {
    return document.getElementById("cell" + row + cell);
}

export class ChessDesk {
    constructor() {
        this.desk = [];
        for (let f of [FigureType.rook,
            FigureType.house,
            FigureType.bishop,
            FigureType.queen,
            FigureType.king,
            FigureType.bishop,
            FigureType.house,
            FigureType.rook]) {
            this.desk.push(new Figure(FigureColor.black, f));
        }
        for (let i = 0; i < 8; i++) this.desk.push(new Figure(FigureColor.black, FigureType.pawn));
        for (let i = 0; i < 32; i++) this.desk.push(undefined);
        for (let i = 0; i < 8; i++) this.desk.push(new Figure(FigureColor.white, FigureType.pawn)); 
        for (let f of [FigureType.rook,
        FigureType.house,
        FigureType.bishop,
        FigureType.king,
        FigureType.queen,
            FigureType.bishop,
            FigureType.house,
            FigureType.rook]) {
            this.desk.push(new Figure(FigureColor.white, f));
        }
        this.currentPlayer = FigureColor.white;
    }
    getCell(row, column) {
        return this.desk[row * 8 + column];
    }

    refreshDesk() {
        for (let i = 0; i < 8; i++) {
            for (let j = 0; j < 8; j++) {
                let cell = this.getCell(i, j);
                let cellElement = getCellElementByIndex(i, j);
                cellElement.classList.remove(CSSCellState.chessCellCanMove);
                if (cell !== undefined) {
                    if (cell.canMoves.length > 0)
                        cellElement.classList.add(CSSCellState.chessCellCanMove);
                    cell.drawFigure(cellElement);
                }

            }
        }



    }
    //putFigures() {
    //    this.desk.push(new ChessCell(0, 0, new Rook(FigureColor.black), deskElement));
    //    this.desk.push(new ChessCell(0, 1, new Horse(FigureColor.black), deskElement));
    //    this.desk.push(new ChessCell(0, 2, new Bishop(FigureColor.black), deskElement));
    //    this.desk.push(new ChessCell(0, 3, new Queen(FigureColor.black), deskElement));
    //    this.desk.push(new ChessCell(0, 4, new King(FigureColor.black), deskElement));
    //    this.desk.push(new ChessCell(0, 5, new Bishop(FigureColor.black), deskElement));
    //    this.desk.push(new ChessCell(0, 6, new Horse(FigureColor.black), deskElement));
    //    this.desk.push(new ChessCell(0, 7, new Rook(FigureColor.black), deskElement));
    //    for (let i = 0; i < 8; i++) this.desk.push(new ChessCell(1, i, new Pawn(FigureColor.black), deskElement));
    //    for (let i = 0; i < 8; i++) this.desk.push(new ChessCell(6, i, new Pawn(FigureColor.white), deskElement));
    //    this.desk.push(new ChessCell(7, 0, new Rook(FigureColor.white), deskElement));
    //    this.desk.push(new ChessCell(7, 1, new Horse(FigureColor.white), deskElement));
    //    this.desk.push(new ChessCell(7, 2, new Bishop(FigureColor.white), deskElement));
    //    this.desk.push(new ChessCell(7, 3, new King(FigureColor.white), deskElement));
    //    this.desk.push(new ChessCell(7, 4, new Queen(FigureColor.white), deskElement));
    //    this.desk.push(new ChessCell(7, 5, new Bishop(FigureColor.white), deskElement));
    //    this.desk.push(new ChessCell(7, 6, new Horse(FigureColor.white), deskElement));
    //    this.desk.push(new ChessCell(7, 7, new Rook(FigureColor.white), deskElement));
    //}


    //_currentPlayer = FigureColor.white;
    //get currentPlayer() { return this._currentPlayer }
    //set currentPlayer(value) {
    //    this._currentPlayer = value;
    //    this.clearClassInDesk(Defines.chessCellCanMove);
    //    this.setHoverForCells();
    //}

    //_selectedCell = undefined;

    //clearClassInDesk(className) {
    //    let elements = document.getElementsByClassName(className);
    //    while (elements.length) {
    //        elements[0].classList.remove(className);
    //    }
    //}


    //clearSelectedCell() {
    //    this.clearClassInDesk(Defines.cellSelected);
    //    this.clearClassInDesk(Defines.chessCellDestinationMark);
    //    this.clearClassInDesk(Defines.figureMustFight);
    //}

    //setSelectedCell(cellElement) {
    //    cellElement.classList.add(Defines.cellSelected);
    //    let cm = this.getCellById(cellElement.id).canMoves;
    //    for (let canMove of cm) {
    //        if (canMove.moveState == MoveState.fight) {
    //            canMove.cell.canBeat = true;
    //        }
    //        canMove.cell.cellElement.classList.add(Defines.chessCellDestinationMark);
    //    }
    //}

    //clickToSameCell(cellElement) {
    //    this.clearSelectedCell();
    //}
    //clickToCanMoveCell(cellElement) {
    //    this.clearSelectedCell();
    //    this.setSelectedCell(cellElement);
    //}
    //clickToAnOtherCell(cellElement) {
    //    if (!cellElement.classList.contains(Defines.chessCellDestinationMark))
    //        this.clearSelectedCell();
    //    else
    //        this.moveFigure(cellElement);
    //}



    //// return cell by id
    //getCellById(id) {
    //    let row = Number(id[4]);
    //    let column = Number(id[5]);
    //    return this.getCell(row, column);
    //}
    //clearCanMovePositions() {
    //    let el = document.getElementsByClassName(window.Defines.chessCellDestinationMark);
    //    while (el.length) {
    //        el[0].classList.remove(window.Defines.chessCellDestinationMark);
    //    }
    //}
    //removeFigure(cell) {
    //    cell.figure = undefined;
    //}


    //// move selected figure to destination cell
    //moveFigure(cellElement) {
    //    let selectedElement = document.getElementsByClassName(Defines.cellSelected)[0];
    //    this.clearSelectedCell();
    //    let cell = this.getCellById(selectedElement.id);
    //    let targetCell = this.getCellById(cellElement.id);
    //    if (targetCell.figure != undefined) this.removeFigure(targetCell);
    //    targetCell.figure = cell.figure;
    //    cell.figure = undefined;
    //    if (this.currentPlayer == FigureColor.white)
    //        this.currentPlayer = FigureColor.black;
    //    else
    //        this.currentPlayer = FigureColor.white;
    //    // Ajax
    //    let xhttp = new XMLHttpRequest();
    //    let msg = JSON.stringify({ "row": cell.row, "column": cell.column, "destinationRow": targetCell.row, "destinationColumn": targetCell.column });
    //    let fdPost = new FormData();
    //    fdPost.append("row", cell.row);
    //    fdPost.append('column', cell.column);
    //    fdPost.append('destinationRow', targetCell.row);
    //    fdPost.append('destinationColumn', targetCell.column);

    //    //fdPost.append("data", msg);
    //    xhttp.open("POST", "/Chess?handler=move", true);
    //    xhttp.timeout = 9000;
    //    ////xhttp.responseType = "json";
    //    //xhttp.setRequestHeader("Content-Type", 'application/json; charset=utf-8');
    //    xhttp.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
    //    //xhttp.onload = function () {
    //    //    if (xhttp.status === 200) {
    //    //        //var userInfo = JSON.parse(xhttp.responseText);
    //    //    }
    //    //};
    //    xhttp.send(fdPost);

    //    //$.ajax({
    //    //    type: "POST",
    //    //    url: "/Chess?handler=move",
    //    //    beforeSend: function (xhr) {
    //    //        xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
    //    //    },
    //    //    data: msg,
    //    //    contentType : "application/json; charset=utf-8",
    //    //    dataType: "json",
    //    //    success: function (response) {
    //    //        //var dvItems = $("#dvPostItems");
    //    //        //dvItems.empty();
    //    //        //$.each(response, function (i, item) {
    //    //        //    var $tr = $('<li>').append(item).appendTo(dvItems);
    //    //        //});
    //    //        let a = 10;
    //    //    },
    //    //    failure: function (response) {
    //    //        alert(response);
    //    //    }
    //    //})

    //}

    //selectFigure(cellElement) {
    //    // if exist selected figure
    //    let cell = this.getCellById(cellElement.id);
    //    if (cell == this.selectedItem) {
    //        // click to the same figure
    //        cellElement.classList.remove(window.Defines.cellSelected);
    //        this.clearCanMovePositions();
    //    } else {
    //        // click to anathe figure or first figure
    //        if (this.selectedItem == undefined) {
    //            // first click
    //            cellElement.classList.add(window.Defines.cellSelected);
    //            for (let targetCell of cell.canMoves) {
    //                targetCell.cell.cellElement.classList.add(window.Defines.chessCellCanMove);
    //            }


    //            //this.canMovePositions = this.getMovePositions(this.getCellById(cellElement.id));
    //            //for (let cell of this.canMovePositions) {
    //            //    cell.cell.cellElement.classList.add(window.Defines.chessCellCanMove);
    //            //}
    //        } else {

    //        }

    //        cellElement.classList.remove(Defines.cellSelected);
    //        cellElement.classList.add(Defines.cellSelected);
    //    }



    //    cellElement.classList.add(Defines.cellSelected);
    //    this.canMovePositions = this.getMovePositions(this.getCellById(cellElement.id));
    //    for (let cell of this.canMovePositions) {
    //        cell.cell.cellElement.classList
    //    }

    //}
    //addDivElement(html, className, owner) {
    //    let gripDeskCell = document.createElement("div");
    //    gripDeskCell.innerHTML = html;
    //    gripDeskCell.style.userSelect = 'none';
    //    gripDeskCell.classList.add(className);//<div class="gripDeskRow">a</div>
    //    owner.appendChild(gripDeskCell);
    //}
    //getCell(row, column) {
    //    return this.desk[row * 8 + column];
    //}

    //getMovePositions(cell) {
    //    let result = [];
    //    if (cell.figure == undefined) return result;
    //    for (let i = 0; i < 8; i++) {
    //        for (let j = 0; j < 8; j++) {
    //            let r = cell.figure.checkMove(cell.row, cell.column, i, j);
    //            if (r == MoveState.can || r == MoveState.fight) {
    //                result.push(new CanMoveDestination(this.getCell(i, j), r));
    //            }
    //        }
    //    }
    //    return result;
    //}
    //setHoverForCells() {
    //    for (let cell of this.desk) {
    //        cell.canMoves = this.getMovePositions(cell);
    //        if (cell.canMoves.length > 0) {
    //            cell.cellElement.classList.add(window.Defines.chessCellCanMove);
    //            cell.cellElement.draggable = true;
    //        }
    //        else {
    //            cell.cellElement.classList.remove(window.Defines.chessCellCanMove);
    //            cell.cellElement.draggable = false;
    //        }
    //    }
    //}

}

//function chessDeskCellClick(event) {
//    if (this.classList.contains(Defines.cellSelected)) // DOM
//        chessDesk.clickToSameCell(this);
//    else {
//        if (this.classList.contains(Defines.chessCellCanMove))
//            chessDesk.clickToCanMoveCell(this);
//        else
//            chessDesk.clickToAnOtherCell(this);
//    }
//}

export var chessDesk = new ChessDesk();


