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
function init(Desk,drag){
    if(drag){
        for(let i = 0;i < Desk.length;i++){
            Desk[i].cellElement.ondragstart = dragCell;
            Desk[i].cellElement.ondragover = allowDropCell;
            Desk[i].cellElement.ondrop = dropCell;
        }
    }
    else{
        for(let i = 0;i < Desk.length;i++){
            Desk[i].cellElement.ondragstart = undefined;
            Desk[i].cellElement.ondragover = undefined;
            Desk[i].cellElement.ondrop = undefined;
            Desk[i].cellElement.draggable = false;
        }
    }
}
export { init };