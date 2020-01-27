import React, { Component } from 'react';
import Axios from 'axios';
import UserObject from './UserObject';
import PostUser from './PostUser';

export class DisplayUser extends Component {
    constructor() {
        super();
        this.componentDidMount = this.componentDidMount.bind(this);
        this.handler = this.componentDidMount.bind(this);
    }
    state = {
        userList: []
        
    }
    componentDidMount() {
        Axios.get('/api/user/users')
            .then(response => {
                this.setState({userList: response.data});
                console.log(response.data);
            });
    }

    handler() {
        this.componentDidMount;
    }

    render() {
        const user = this.state.userList.map(user => {
            return <UserObject key={user.id} id={user.id} firstName={user.firstName} lastName={user.lastName} address={user.address}/>
        });
        return (
            <div>
                <p>
                    {user}
                </p>
                <p>
                    <PostUser action={this.handler}/>
                </p>
        </div>
        );
    }

}

