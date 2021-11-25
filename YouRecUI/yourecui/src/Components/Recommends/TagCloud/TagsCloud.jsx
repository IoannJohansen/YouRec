import { TagCloud } from 'react-tagcloud';
import './TagsCloud.css';

const data = [
    { value: 'JavaScript', count: 38, key: 1 },
    { value: 'React', count: 30, key: 2 },
    { value: 'Nodejs', count: 28, key: 3 },
    { value: 'Express.js', count: 25, key: 4 },
    { value: 'HTML5', count: 33, key: 5 },
    { value: 'MongoDB', count: 18, key: 6 },
    { value: 'CSS3', count: 20, key: 7 },
    { value: 'JavaScript', count: 38, key: 8 },
    { value: 'React', count: 30, key: 9 }
];

const options = {
    luminosity: 'light',
    hue: 'blue'
}

export default function TagsCloud() {
    return (
        <div className="container">
            <p bg="primary" className="text-center h3">Available tags</p>
            <TagCloud
                className="TagCloud col-sm-4"
                minSize={12}
                maxSize={35}
                colorOptions={options}
                tags={data}
                onClick={tag => alert(`'${tag.value}' was selected!`)}
            />
        </div>
    );
}