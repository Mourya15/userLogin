import React, { Component } from 'react';

const userObject = (props) => {
    return (<div>
        <p>test</p>
        <p>{props.id}</p>
        <p>{props.lastName}</p>
        <p>{props.firstName}</p>
        <p>{props.address}</p>
        <p>{props.livonia}</p>
    </div>);
}

export default userObject;