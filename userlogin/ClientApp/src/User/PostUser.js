import React, { Component } from 'react'
import axios from 'axios'
export default class PostUser extends Component {
    constructor(props) {
        super(props)

        this.state = {
            id: '',
            firstName: '',
            address: ''
        }
    }

    changeHandler = e => {
        this.setState({ [e.target.name]: e.target.value })
    }

    submitHandler = e => {
        e.preventDefault()
        console.log(this.state)
        const postUser = {
            id: this.state.id,
            firstName: this.state.firstName,
            address: this.state.address
        }
        axios
            .post('/api/user/users', postUser)
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error)
            })
    }

    render() {
        return (
            <div>
                <form onSubmit={this.submitHandler}>
                    <div>
                        <input
                            type="text"
                            name="id"
                            value={this.state.id}
                            onChange={this.changeHandler}
                        />
                    </div>
                    <div>
                        <input
                            type="text"
                            name="firstName"
                            value={this.state.firstName}
                            onChange={this.changeHandler}
                        />
                    </div>
                    <div>
                        <input
                            type="text"
                            name="address"
                            value={this.state.address}
                            onChange={this.changeHandler}
                        />
                    </div>
                    <button onClick={this.props.action}>reload</button>
                    <button type="submit">Submit</button>
                </form>
            </div>
        )
    }
}
