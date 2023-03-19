import React, { Component } from 'react'
import { variables } from './Variables'

export class Items extends Component {
  constructor(props) {
    super(props)
    this.state = {
      items: [],
      modalTitle: '',
      itemId: 0,
      categoryId: 0,
      itemName: '',
      itemValue: '',
    }
  }

  refreshItems() {
    fetch(variables.API_URL + 'Items')
      .then((response) => response.json())
      .then((data) => {
        this.setState({ items: data })
      })
  }

  componentDidMount() {
    this.refreshItems()
  }

  changeCategory = (e) => {
    this.setState({ categoryId: e.target.value })
  }

  changeItemName = (e) => {
    this.setState({ itemName: e.target.value })
  }

  changeItemValue = (e) => {
    this.setState({ itemValue: e.target.value })
  }

  addClick() {
    this.setState({
      modalTitle: 'Add Item',
      categoryId: 0,
      itemName: '',
      itemValue: '',
    })
  }

  createItemClick() {
    fetch(variables.API_URL + 'Items', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        categoryId: this.state.categoryId,
        itemName: this.state.itemName,
        itemValue: this.state.itemValue,
      }),
    })
      .then((res) => res.json())
      .then(
        (result) => {
          alert('Item was added to the list')
          this.refreshItems()
        },
        (error) => {
          alert('Add Failed')
        }
      )
  }

  deleteItemClick(id) {
    if (window.confirm('Are you sure you want to delete the item?')) {
      fetch(variables.API_URL + 'Items/' + id, {
        method: 'DELETE',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
      })
        .then((res) => res.json())
        .then(
          (result) => {
            this.refreshItems()
          },
          (error) => {
            this.refreshItems()
          }
        )
    }
  }

  render() {
    const { items, modalTitle, categoryId, itemName, itemValue } = this.state
    return (
      <React.Fragment>
        <div className="container">
          <h1 className="text-center my-5">All Items by Categories</h1>
          <div className="row">
            <div className="col-4"></div>
            <div className="col-4"></div>
            <div className="col-4 py-3">
              <button
                type="button"
                className="btn btn-success"
                title="Add a New Item"
                data-bs-toggle="modal"
                data-bs-target="#modalAddItem"
                onClick={() => this.addClick()}
              >
                <i className="bi bi-plus-circle"></i>
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="16"
                  height="16"
                  fill="currentColor"
                  className="bi bi-plus-circle me-2"
                  viewBox="0 0 16 16"
                >
                  <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z" />
                  <path d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4z" />
                </svg>
                Add a New Item
              </button>
            </div>
          </div>
          <table className="table table-striped">
            <thead>
              <tr>
                <th>Category | Item</th>
                <th>Category Total | Item Value</th>
                <th>Actions</th>
              </tr>
            </thead>
            <tbody>
              {items.map((item) => (
                <tr key={item.categoryId}>
                  <td>{item.itemName}</td>
                  <td>{item.itemValue}</td>
                  <td>
                    <button
                      className="btn"
                      type="button"
                      onClick={() => this.deleteItemClick(item.itemId)}
                    >
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        width="20"
                        height="20"
                        fill="currentColor"
                        className="bi bi-trash3"
                        viewBox="0 0 18 18"
                      >
                        <path d="M6.5 1h3a.5.5 0 0 1 .5.5v1H6v-1a.5.5 0 0 1 .5-.5ZM11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3A1.5 1.5 0 0 0 5 1.5v1H2.506a.58.58 0 0 0-.01 0H1.5a.5.5 0 0 0 0 1h.538l.853 10.66A2 2 0 0 0 4.885 16h6.23a2 2 0 0 0 1.994-1.84l.853-10.66h.538a.5.5 0 0 0 0-1h-.995a.59.59 0 0 0-.01 0H11Zm1.958 1-.846 10.58a1 1 0 0 1-.997.92h-6.23a1 1 0 0 1-.997-.92L3.042 3.5h9.916Zm-7.487 1a.5.5 0 0 1 .528.47l.5 8.5a.5.5 0 0 1-.998.06L5 5.03a.5.5 0 0 1 .47-.53Zm5.058 0a.5.5 0 0 1 .47.53l-.5 8.5a.5.5 0 1 1-.998-.06l.5-8.5a.5.5 0 0 1 .528-.47ZM8 4.5a.5.5 0 0 1 .5.5v8.5a.5.5 0 0 1-1 0V5a.5.5 0 0 1 .5-.5Z" />
                      </svg>
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>

        {/* Modal window for adding an item */}
        <div
          className="modal fade"
          id="modalAddItem"
          tabIndex="-1"
          aria-hidden="true"
        >
          <div className="modal-dialog modal-lg modal-dialog-centered">
            <div className="modal-content">
              <div className="modal-header">
                <h5 className="modal-title">{modalTitle}</h5>
                <button
                  type="button"
                  className="btn-close"
                  data-bs-dismiss="modal"
                  aria-label="Close"
                ></button>
              </div>

              <div className="modal-body">
                <div className="input-group mb-3">
                  <span className="input-group-text">Category ID</span>
                  <input
                    type="number"
                    className="form-control"
                    value={categoryId}
                    onChange={this.changeCategory}
                  ></input>
                </div>
              </div>

              <div className="modal-body">
                <div className="input-group mb-3">
                  <span className="input-group-text">Item Name</span>
                  <input
                    type="text"
                    className="form-control"
                    value={itemName}
                    onChange={this.changeItemName}
                  ></input>
                </div>
              </div>

              <div className="modal-body">
                <div className="input-group mb-3">
                  <span className="input-group-text">Item Value, $</span>
                  <input
                    type="number"
                    className="form-control"
                    value={itemValue}
                    onChange={this.changeItemValue}
                  ></input>
                </div>
              </div>

              <button
                type="button"
                className="btn btn-primary float-start"
                onClick={() => this.createItemClick()}
                data-bs-dismiss="modal"
              >
                Create
              </button>
            </div>
          </div>
        </div>

        <footer className="border-top footer text-muted mx-2">
          <div className="text-center">&copy; Marat Nikitin, 2023</div>
        </footer>
      </React.Fragment>
    )
  }
}
