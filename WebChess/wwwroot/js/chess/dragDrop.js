function dropCell(ev) {
    ev.preventDefault();
    let data = ev.dataTransfer.getData("cellCords");
    let Targetcell = globalThis.playerDesk.chessDesk.getCellById(ev.target.id);
    globalThis.playerDesk.chessDesk.moveFigure(ev.target);

}

function allowDropCell(ev) {
    ev.preventDefault();
}

function dragCell(ev) {
    let cell = globalThis.playerDesk.chessDesk.getCellById(ev.target.id);
    ev.dataTransfer.setData("cellCords",  { row:cell.row, column:cell.column });
}

export { dropCell,allowDropCell,dragCell };