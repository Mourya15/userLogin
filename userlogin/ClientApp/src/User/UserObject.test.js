﻿import React from 'react';
import { configure, shallow } from 'enzyme';
import Adapter from 'enzyme-adapter-react-16';
import UserObject from './UserObject';

configure({ adapter: new Adapter() });

it('renders without crashing', () => {
    const wrapper = shallow(<UserObject />);
    expect(wrapper.find(p)).toHaveLength(6);
});