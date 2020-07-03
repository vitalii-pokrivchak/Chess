﻿import { Figure } from "./Figure.js";
import { FigureColor } from "./FigureColor.js";

export class Bishop extends Figure {
    constructor(color) {
        super(color);
        this.figureOrder = 2;
    }
    showFigure(cellElement) {
        let draw = this.getDraw(cellElement);
        draw.path('M 9,36 C 12.39,35.03 19.11,36.43 22.5,34 C 25.89,36.43 32.61,35.03 36,36 C 36,36 37.65,36.54 39,38 C 38.32,38.97 37.35,38.99 36,38.5 C 32.61,37.53 25.89,38.96 22.5,37.5 C 19.11,38.96 12.39,37.53 9,38.5 C 7.646,38.99 6.677,38.97 6,38 C 7.354,36.06 9,36 9,36 z');
        draw.path('M 15,32 C 17.5,34.5 27.5,34.5 30,32 C 30.5,30.5 30,30 30,30 C 30,27.5 27.5,26 27.5,26 C 33,24.5 33.5,14.5 22.5,10.5 C 11.5,14.5 12,24.5 17.5,26 C 17.5,26 15,27.5 15,30 C 15,30 14.5,30.5 15,32 z');
        draw.path('M 25 8 A 2.5 2.5 0 1 1  20,8 A 2.5 2.5 0 1 1  25 8 z');
        let p = draw.path('M 17.5,26 L 27.5,26 M 15,30 L 30,30 M 22.5,15.5 L 22.5,20.5 M 20,18 L 25,18');

        if (this.color == FigureColor.black) {
            draw.style('opacity:1; fill:#000000; fill-opacity:1; fill-rule:nonzero; stroke:#000000; stroke-width:1.5; stroke-linecap:round; stroke-linejoin:miter; stroke-miterlimit:4; stroke-dasharray:none; stroke-opacity:1;');
            p.style('fill:none; stroke:#ffffff; stroke-linejoin:miter;');
        } else {
            draw.style('opacity:1; fill:#ffffff; fill-opacity:1; fill-rule:nonzero; stroke:#000000; stroke-width:1.5; stroke-linecap:round; stroke-linejoin:miter; stroke-miterlimit:4; stroke-dasharray:none; stroke-opacity:1;');
            p.style('fill:none; stroke:#000000; stroke-linejoin:miter;');
        }
    }
    checkMove(rowPos, columnPos, rowDestination, columnDestination, color = globalThis.playerDesk.chessDesk.currentPlayer) {
        let chessDesk = globalThis.playerDesk.chessDesk;
        // other color
        if (this.color != color) return MoveState.cannot;

        // self coords
        if (rowPos === rowDestination && columnPos === columnDestination) return MoveState.cannot;

        if (Math.abs(rowPos - rowDestination) !== Math.abs(columnPos - columnDestination)) return MoveState.cannot;

        let idxRow = Math.sign(rowDestination - rowPos);
        let idxColumn = Math.sign(columnDestination - columnPos);

        for (let i = rowPos + idxRow, j = columnPos + idxColumn; i != rowDestination && j != columnDestination; i += idxRow, j += idxColumn) {
            let roadCell = chessDesk.getCell(i, j);
            if (roadCell.figure != undefined) return MoveState.cannot;
        }
        let targetCell = chessDesk.getCell(rowDestination, columnDestination);
        if (targetCell.figure == undefined) return MoveState.can;
        if (targetCell.figure.color === this.color)
            return MoveState.cannot;
        else
            return MoveState.fight;
    }
}