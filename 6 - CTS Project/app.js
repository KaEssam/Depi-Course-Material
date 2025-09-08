const api_url = "http://localhost:5064/api";


const addTodoBtn = document.getElementById("addTodoBtn");
const todoList = document.getElementById("todoList");
const saveTodoBtn = document.getElementById("saveTodoBtn");
const todomodel = document.getElementById("todomodel");




// document.addEventListener("DOMContentLoaded", function () {
//   loadTodos();
// });

window.onload = function () {
  loadTodos();
};

   let todos =[]
async function loadTodos() {

  const res = await fetch(`${api_url}/todos`)
  todos = await res.json()
  render()

  // todos.forEach(todo => {
  // let row =document.createElement("tr")
  //   row.innerHTML =`<td>${todo.id}</td>
  //         <td>${todo.title}</td>
  //         <td><input type="checkbox" ${todo.completed ? "checked" : ""}} /></td>
  //         <td>
  //           <button class="btn btn-outline-warning btn-sm text-dark">
  //             Edit
  //           </button>
  //           <button class="btn btn-outline-danger btn-sm">Delete</button>
  //         </td>`;

  //       todoList.appendChild(row)
  // });
// console.log(todos)
}

function render() {
   todos.forEach(todo => {
  let row =document.createElement("tr")
    row.innerHTML =`<td>${todo.id}</td>
          <td class="${todo.isCompleted ? 'completed-todo': ''}">${todo.title}</td>
          <td><input type="checkbox" ${todo.isCompleted ? 'checked' : ''} onchange="toggleCompleted(${todo.id},this)" /></td>
          <td>
            <button class="btn btn-outline-warning btn-sm text-dark">
              Edit
            </button>
            <button class="btn btn-outline-danger btn-sm" onclick="deleteTodo(${todo.id})">Delete</button>
          </td>`;

        todoList.appendChild(row)
  });
}


async function saveTodo() {
  const title = document.getElementById("todoTitle").value;

  if(!title){
    alert("please enter a title")
    return
  }

  const todo = {
    title,
    isCompleted: false,
  };

 const res = await fetch(`${api_url}/todos`,{
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(todo),

  })

  if(res.ok){
    todomodel
    loadTodos()
  }
}

async function deleteTodo(id) {
  await fetch(`${api_url}/todos/${id}`, {
    method: "DELETE",
  });

  loadTodos();
}




async function toggleCompleted(id,completed) {

await fetch(`${api_url}/todos/${id}`,{
  method: "PATCH",
  headers: {
    "Content-Type": "application/json",
  },
  body: JSON.stringify({completed}),

})

loadTodos()

}
// async function toggleCompleted(id,completed) {

// await fetch(`${api_url}/todos/${id}`,{
//   method: "PUT",
//   headers: {
//     "Content-Type": "application/json",
//   },
//   body: JSON.stringify({title: this.title,completed}),

// })

// loadTodos()

// }



